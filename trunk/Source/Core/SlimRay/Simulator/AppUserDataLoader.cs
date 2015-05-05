﻿using SlimRay.UserData;
using SlimRay.UserData.Entities;
using System.Collections.Generic;
using SlimRay.App;

namespace SlimRay.Simulator
{
    public class AppUserDataLoader : IApp, IUserDataLoader
    {
        private const string _name = "Virtual Userdata loader.";
        private string _key = AppKeys.UserDataLoader;

        public string Name
        {
            get { return _name; }
        }

        public string SerialKey
        {
            get { return _key; }
        }

        private List<IUserData> _allUserData;

        public AppUserDataLoader()
        {
            _allUserData = initAllData();
        }

        private List<IUserData> initAllData()
        {
            List<IUserData> dList = new List<IUserData>();

            UserDataEntity data = new UserDataEntity("Data", "List of all data which is used only in the internal modules.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("Fields", "Field list for all data");
            data.AddField(new UserFieldEntiry("DataID", "Id of data which it belongs to.", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Type", UserFieldType.UnInt32));
            resetFieldID(data);
            dList.Add(data);

            //link data and fields.
            dList[0].Link(dList[1].Fields[0], UserFieldLinkRelation.FieldofList);

            data = new UserDataEntity("Group", "Group for users.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("User", "User who can access and read/write data.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("LoginName", UserFieldType.String));
            data.AddField(new UserFieldEntiry("LoginPassword", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Type", UserFieldType.UnInt32));
            data.AddField(new UserFieldEntiry("Status", UserFieldType.Int32));
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("UserGroup", "Links between user and group.");
            data.AddField(new UserFieldEntiry("UserID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("GroupID", UserFieldType.Int64));
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("User Status", "Status of user.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int32));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            resetFieldID(data);
            dList.Add(data);

            //User group setting should be able to load all detail data of user and group.
            dList[4].Link(dList[2].Fields[0], UserFieldLinkRelation.AnotherPartofData);
            dList[4].Link(dList[3].Fields[0], UserFieldLinkRelation.AnotherPartofData);
            dList[4].Link(dList[5].Fields[0], UserFieldLinkRelation.DataSource);

            return dList;
        }

        private void resetFieldID(IUserData data)
        {
            int index = 0;
            foreach (IUserField field in data.Fields)
            {
                field.ID = index;
                index++;
            }
        }

        public IUserData[] Get()
        {
            return _allUserData.ToArray();
        }

        public IUserData Get(string name)
        {
            foreach (var data in _allUserData)
            {
                if (data.Name == name)
                {
                    return data;
                }
            }

            return null;
        }
    }
}