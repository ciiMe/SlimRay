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

        public bool SetFieldName(string dataName, string fieldName, string newName)
        {
            string dataNameInData = "";
            string fieldNameInData = "";

            //get id of data which field valie is :fieldNameInData from system tables(UserData table).
            int id = 0;

            UpdateRequest request = new UpdateRequest
            {
                Target = UpdateTarget.Field,
                Action = UpdateAction.Update,

                TableName = dataNameInData,
                ColumnName = fieldNameInData,
                DataValue = newName,
                Id = id
            };

            TableManager tm = new TableManager();
            return tm.ExecuteDataRequest(new UpdateRequest[] { request });
        }

        public bool SetFieldDescription(string dataName, string fieldName, string description)
        {
            throw new NotImplementedException();
        }

        public bool SetFieldType(string dataName, string fieldName, UserFieldType t)
        {
            throw new NotImplementedException();
        }

        public bool RemoveField(string dataName, string fieldName)
        {
            throw new NotImplementedException();
        }
    }
}
