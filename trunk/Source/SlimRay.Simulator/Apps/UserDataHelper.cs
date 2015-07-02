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
    public class UserDataHelper : BaseApp, ISimulatorApp, IUserDataHelperApp
    {
        private List<IUserData> _allUserData;

        public UserDataHelper()
        {
            _name = "Virtual Userdata loader.";
            _description = "This simulator app keep virtual data in memory, it does not call DataManager to do real actions, this app only show how UserData is used in view.";
            _key = AppKeys.UserDataAdapter;
            _version = "0.1";

            _allUserData = initAllData();
        }

        private List<IUserData> initAllData()
        {
            List<IUserData> dList = new List<IUserData>();

            UserDataEntity data = new UserDataEntity("Data", "List of all data which is used only in the internal modules.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.ID = dList.Count;
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("Fields", "Field list for all data");
            data.AddField(new UserFieldEntiry("DataID", "Id of data which it belongs to.", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Type", UserFieldType.UnInt32));
            data.ID = dList.Count;
            resetFieldID(data);
            dList.Add(data);

            //link data and fields.
            dList[0].Link(dList[1].Fields[0], UserFieldLinkRelation.FieldofList);

            data = new UserDataEntity("Group", "Group for users.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.ID = dList.Count;
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
            data.ID = dList.Count;
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("UserGroup", "Links between user and group.");
            data.AddField(new UserFieldEntiry("UserID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("GroupID", UserFieldType.Int64));
            data.ID = dList.Count;
            resetFieldID(data);
            dList.Add(data);

            data = new UserDataEntity("User Status", "Status of user.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int32));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.ID = dList.Count;
            resetFieldID(data);
            dList.Add(data);

            //User group setting should be able to load all detail data of user and group.
            dList[4].Link(dList[2].Fields[0], UserFieldLinkRelation.AnotherPartofData);
            dList[4].Link(dList[3].Fields[0], UserFieldLinkRelation.AnotherPartofData);

            //link user and user status.
            dList[3].Link(dList[5].Fields[0], UserFieldLinkRelation.DataSource);

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
            IUserData data = new UserDataEntity(name, description);
            data.ID = _allUserData.Count;
            _allUserData.Add(data);

            return true;
        }

        public bool SetNewName(string dataName, string newName)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == dataName)
                {
                    IUserData data = _allUserData[i];
                    data.Name = newName;
                    _allUserData[i] = data;
                    return true;
                }
            }
            return false;
        }

        public bool SetDescription(string name, string description)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == name)
                {
                    IUserData data = _allUserData[i];
                    data.Description = description;
                    _allUserData[i] = data;
                    return true;
                }
            }
            return false;
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
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == name)
                {
                    _allUserData.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public IUserField[] GetFields(string dataName)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == dataName)
                {
                    IUserField[] result = new IUserField[_allUserData[i].Fields.Length];
                    _allUserData[i].Fields.CopyTo(result, 0);
                    return result;
                }
            }
            return new IUserField[] { };
        }

        public IUserField GetField(string dataName, string fieldName)
        {
            foreach (IUserData data in _allUserData)
            {
                if (data.Name == dataName)
                {
                    foreach (IUserField field in data.Fields)
                    {
                        if (field.Name == fieldName)
                        {
                            return field;
                        }
                    }
                }
            }

            return null;
        }

        public bool AddField(string dataName, string fieldName, UserFieldType t, string description)
        {
            var data = Get(dataName);
            data.AddField(new UserFieldEntiry(fieldName, description, t));

            return true;
        }

        public bool RemoveField(string dataName, string fieldName)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == dataName)
                {
                    var data = Get(dataName);
                    data.RemoveFiled(fieldName);
                }
            }

            return true;
        }

        public bool SetFieldName(string dataName, string fieldName, string newName)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == dataName)
                {
                    var data = _allUserData[i];

                    for (int j = 0; j < data.Fields.Length; j++)
                    {
                        if (data.Fields[j].Name == fieldName)
                        {
                            data.Fields[j].Name = newName;
                            _allUserData[i] = data;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool SetFieldDescription(string dataName, string fieldName, string description)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == dataName)
                {
                    var data = _allUserData[i];

                    for (int j = 0; j < data.Fields.Length; j++)
                    {
                        if (data.Fields[j].Name == fieldName)
                        {
                            data.Fields[j].Description = description;
                            _allUserData[i] = data;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public IUserData[] GetLinkedData(string dataName)
        {
            IUserData data = Get(dataName);

            List<IUserData> ld = new List<IUserData>();

            foreach (LinkedUserField field in data.LinkedFields)
            {
                ld.Add(field.Field.Data);
            }

            return ld.ToArray();
        }

        public bool SetFieldType(string dataName, string fieldName, UserFieldType t)
        {
            for (int i = 0; i < _allUserData.Count; i++)
            {
                if (_allUserData[i].Name == dataName)
                {
                    var data = _allUserData[i];

                    for (int j = 0; j < data.Fields.Length; j++)
                    {
                        if (data.Fields[j].Name == fieldName)
                        {
                            data.Fields[j].Type = t;
                            _allUserData[i] = data;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
