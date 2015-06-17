using System;
using System.Collections.Generic;
using SlimRay.Data;
using System.Data;

namespace SlimRay.UserData.Adapter
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

            //todo: where is it from?
            TableUserData table = new TableUserData();

            DataTable dt = tm.LoadData(table.TableName);

            List<IUserData> result = new List<IUserData>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(fromDataRow(row));
            }

            return result;
        }

        public void SetStorage(IUserData data, DB.DBAddress address)
        {
            TableManager tm = new TableManager();

            //todo: get table name of this data.
            string tableName = "";

            //todo: where is it from?
            TableUserDataStorage uds = new TableUserDataStorage();

            tm.UpdateFieldData(tableName, data.ID, uds.AddressKeyFieldName, address.Key);
            tm.UpdateFieldData(tableName, data.ID, uds.AddressFieldName, address.HostAddress);
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
            TableUserDataFIelds udf = new TableUserDataFIelds();

            IUserField field = data.Field(fieldName);

            tm.UpdateFieldData(tableName, field.ID, udf.NameFieldName, newName);

            return true;
        }
    }
}
