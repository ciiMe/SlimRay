using SlimRay.UserData;
using System.Collections.Generic;
using SlimRay.App;
using SlimRay.App.Loaders;

namespace SlimRay.Addins.Simulator.Apps
{
    /*
     * it simulate a data loader,
     * a data loader should load data from db, 
     * but this app return virtual data directly.
     */
    public class UserDataLoader : ISimulatorApp, IUserDataHelperApp
    {
        private const string _name = "Virtual Userdata loader.";
        private const string _description = "Load all Userdata.";
        private string _key = AppKeys.UserDataAdapter;

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetKey()
        {
            return _key;
        }

        private List<IUserData> _allUserData;

        public UserDataLoader()
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
            name = name.Trim().ToUpper();

            foreach (var data in _allUserData)
            {
                if (data.Name.ToUpper() == name)
                {
                    return data;
                }
            }

            return null;
        }


        public bool AddData(string name, string description)
        {
            throw new System.NotImplementedException();
        }

        public bool SetNewName(string dataName, string newName)
        {
            throw new System.NotImplementedException();
        }

        public bool SetDescription(string name, string description)
        {
            throw new System.NotImplementedException();
        }

        public DB.DBAddress GetStorage(string dataName)
        {
            throw new System.NotImplementedException();
        }

        public void SetStorage(string dataName, DB.DBAddress address)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(string name)
        {
            throw new System.NotImplementedException();
        }

        public IUserField[] GetFields(string dataName)
        {
            throw new System.NotImplementedException();
        }

        public IUserField GetField(string dataName, string fieldName)
        {
            throw new System.NotImplementedException();
        }

        public bool AddField(string dataName, string fieldName)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveField(string dataName, string fieldName)
        {
            throw new System.NotImplementedException();
        }

        public bool RenameField(string dataName, string fieldName, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}
