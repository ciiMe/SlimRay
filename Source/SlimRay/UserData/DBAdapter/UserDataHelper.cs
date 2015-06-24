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

        public IUserData[] Get()
        {
            TableManager tm = new TableManager();
            TableUserData table = SystemTables.UserData;
            DataTable dt = tm.LoadData(table.TableName);

            List<IUserData> result = new List<IUserData>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(fromDataRow(row));
            }

            return result.ToArray();
        }

        public IUserData Get(string dataName)
        {
            //todo: fix it!
            throw new NotImplementedException();
        }

        public IUserData[] GetLinkedData(string dataName)
        {
            throw new NotImplementedException();
        }

        public bool AddData(string name, string description)
        {
            TableManager tm = new TableManager();

            //todo: add record to datatable.

            return true;
        }

        public bool SetNewName(string dataName, string newName)
        {
            throw new NotImplementedException();
        }

        public bool SetDescription(string name, string description)
        {
            throw new NotImplementedException();
        }

        public DBAddress GetStorage(string dataName)
        {
            //todo: fix it!
            return new DBAddress();
        }

        public void SetStorage(string dataName, DBAddress address)
        {
            IUserData data = Get(dataName);
            var table = SystemTables.GetMappedTable(dataName);

            TableManager tm = new TableManager();
            var uds = SystemTables.UserDataStorage;
            tm.UpdateFieldData(table.TableName, data.ID, uds.AddressKeyFieldName, address.Key);
            tm.UpdateFieldData(table.TableName, data.ID, uds.AddressFieldName, address.HostAddress);
        }

        public bool Remove(string name)
        {
            TableManager tm = new TableManager();

            //todo: remove record from datatable.

            return true;
        }

        public IUserField[] GetFields(string dataName)
        {
            throw new NotImplementedException();
        }

        public IUserField GetField(string dataName, string fieldName)
        {
            throw new NotImplementedException();
        }

        public bool AddField(string dataName, string fieldName, UserFieldType t, string description)
        {
            throw new NotImplementedException();
        }

        public bool RenameField(string dataName, string fieldName, string newName)
        {
            string tableName = SystemTables.GetMappedTable(dataName).TableName;
            IUserField field = GetField(dataName, fieldName);

            TableManager tm = new TableManager();
            TableUserDataFields udf = SystemTables.UserDataFields;
            tm.UpdateFieldData(tableName, field.ID, udf.NameFieldName, newName);

            return true;
        }

        public bool RemoveField(string dataName, string fieldName)
        {
            throw new NotImplementedException();
        }

        public bool SetFieldType(string dataName, string fieldName, UserFieldType t)
        {
            throw new NotImplementedException();
        }
    }
}
