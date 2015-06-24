using SlimRay.DB;
using SlimRay.App;

namespace SlimRay.UserData
{
    public interface IUserDataHelper : ILoaderApp<IUserData>
    {
        /// <summary>
        /// get the list of all userdata.
        /// </summary>
        //IUserData[] Get();

        /// <summary>
        /// get data by name.
        /// </summary>
        IUserData Get(string dataName);

        /// <summary>
        /// get the data links to.
        /// </summary>
        /// <returns></returns>
        IUserData[] GetLinkedData(string dataName);

        /// <summary>
        /// create new userdata
        /// </summary>
        bool AddData(string name, string description);

        /// <summary>
        /// set a new name for userdata.
        /// </summary>
        bool SetNewName(string dataName, string newName);

        /// <summary>
        /// set description for userdata.
        /// </summary>
        bool SetDescription(string name, string description);

        /// <summary>
        /// get storage place of userdata.
        /// </summary>
        DBAddress GetStorage(string dataName);

        /// <summary>
        /// set the storage address of userdata.
        /// </summary>
        void SetStorage(string dataName, DBAddress address);

        /// <summary>
        /// remove the userdata from system.
        /// </summary>
        bool Remove(string name);

        /// <summary>
        /// get all fields of userdata.
        /// </summary>
        IUserField[] GetFields(string dataName);

        /// <summary>
        /// get field of userdata.
        /// </summary>
        IUserField GetField(string dataName, string fieldName);

        /// <summary>
        /// add field to a userdata.
        /// </summary>
        bool AddField(string dataName, string fieldName, UserFieldType t, string description);

        /// <summary>
        /// remove the field from userdata.
        /// </summary>
        bool RemoveField(string dataName, string fieldName);

        /// <summary>
        /// update field name.
        /// </summary>
        bool RenameField(string dataName, string fieldName, string newName);

        /// <summary>
        /// set type to field.
        /// </summary>
        bool SetFieldType(string dataName, string fieldName, UserFieldType t);
    }
}
