using System;

using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public class SystemData : ISystemData
    {
        public IUserField _name;
        public IUserField _description;

        public IUserField _createDate;
        public IUserField _createUserID;
        public IUserField _createUserAccount;

        public SystemData()
        {

        }

        public IUserField CreateDate
        {
            get { throw new NotImplementedException(); }
        }

        public IUserField CreateUserID
        {
            get { throw new NotImplementedException(); }
        }

        public IUserField CreateUserAccount
        {
            get { throw new NotImplementedException(); }
        }

        public int ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IUserField[] Fields
        {
            get { throw new NotImplementedException(); }
        }

        public LinkedUserField[] LinkedFields
        {
            get { throw new NotImplementedException(); }
        }

        public void AddField(IUserField field)
        {
            throw new NotImplementedException();
        }

        public void RemoveFiled(string name)
        {
            throw new NotImplementedException();
        }

        public void Link(IUserField field, UserFieldLinkRelation relation)
        {
            throw new NotImplementedException();
        }

        public void UnLink(string fieldName)
        {
            throw new NotImplementedException();
        }

        public void UnLink(int index)
        {
            throw new NotImplementedException();
        }

        public IUserField Field(string name)
        {
            throw new NotImplementedException();
        }
    }
}
