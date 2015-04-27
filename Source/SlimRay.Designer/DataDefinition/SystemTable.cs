using System;

using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public class SystemData : ISystemData
    {
        private IField _id;
        public IField _name;
        public IField _description;

        public IField _createDate;
        public IField _createUserID;
        public IField _createUserAccount;

        public SystemData()
        {

        }

        public IField CreateDate
        {
            get { throw new NotImplementedException(); }
        }

        public IField CreateUserID
        {
            get { throw new NotImplementedException(); }
        }

        public IField CreateUserAccount
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

        public IField[] Fields
        {
            get { throw new NotImplementedException(); }
        }

        public LinkedField[] LinkedFields
        {
            get { throw new NotImplementedException(); }
        }

        public void AddField(IField field)
        {
            throw new NotImplementedException();
        }

        public void RemoveFiled(int index)
        {
            throw new NotImplementedException();
        }

        public void Link(IField field, FieldLinkRelation relation)
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
    }
}
