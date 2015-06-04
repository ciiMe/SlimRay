
namespace SlimRay.UserData.Adapter
{
    public class InnerData
    {
        private IUserData _userDataStorageAddress;
        private IUserData _userData;

        public IUserData UserDataStorageAddress
        {
            get { return _userDataStorageAddress; }
            set { _userDataStorageAddress = value; }
        }

        public InnerData()
        {
            initialize();
        }

        private void initialize()
        {
            IUserField field;
            _userDataStorageAddress = new UserDataEntity("UserDataStorageAddress", "Saves the address where userdata saved.");

            field = new UserFieldEntiry("UserDataID", "ID of userdata.", UserFieldType.Int32);
            _userDataStorageAddress.AddField(field);

            field = new UserFieldEntiry("AddressKey", "Key of the storage address DB type(ref:DB.DBAddress).", UserFieldType.String);
            _userDataStorageAddress.AddField(field);
            field = new UserFieldEntiry("AddressHostAddress", "Host address of the storage address DB type(ref:DB.DBAddress).", UserFieldType.String);
            _userDataStorageAddress.AddField(field);
        }

        private void initUserData()
        { 
            
        }
    }
}
