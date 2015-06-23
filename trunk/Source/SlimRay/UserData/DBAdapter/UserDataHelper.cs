using System;
using System.Collections.Generic;
using SlimRay.Data;
using System.Data;
using SlimRay.DB;

namespace SlimRay.UserData.DBAdapter
{
    public class UserDataHelper : IUserDataHelper
    {
        private IUserData fromDataRow(DataRow row)
        {
            return null;
        }

        public List<IUserData> GetAllUserData()
        {
            TableManager tm = new TableManager();
            TableUserData table = SystemTables.UserData;
            DataTable dt = tm.LoadData(table.TableName);

            List<IUserData> result = new List<IUserData>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(fromDataRow(row));
            }

            return result;
        }

        public void SetStorage(IUserData data, DBAddress address)
        {
            TableManager tm = new TableManager();
            var table = SystemTables.GetMappedTable(data);
            var uds = new TableUserDataStorage();

            tm.UpdateFieldData(table.TableName, data.ID, uds.AddressKeyFieldName, address.Key);
            tm.UpdateFieldData(table.TableName, data.ID, uds.AddressFieldName, address.HostAddress);
        }

        public bool AddUserData(IUserData data)
        {
            TableManager tm = new TableManager();

            //todo: add record to datatable.

            return true;
        }

        public bool RemoveUserData(string name)
        {
            TableManager tm = new TableManager();

            //todo: remove record from datatable.

            return true;
        }

        public bool AddField(IUserData data, string fieldName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveField(IUserData data, string fieldName)
        {
            throw new NotImplementedException();
        }

        public bool RenameField(IUserData data, string fieldName, string newName)
        {
            TableManager tm = new TableManager();

            //todo: get table name of this data.
            string tableName = "";

            //todo: where is it from?
            TableUserDataFields udf = new TableUserDataFields();

            IUserField field = data.Field(fieldName);

            tm.UpdateFieldData(tableName, field.ID, udf.NameFieldName, newName);

            return true;
        }
    }
}
