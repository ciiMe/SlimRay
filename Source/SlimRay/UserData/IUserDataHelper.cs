using SlimRay.DB;
using System.Collections.Generic;

namespace SlimRay.UserData
{
    public interface IUserDataHelper
    {
        /// <summary>
        /// get the list of all userdata.
        /// </summary>
        List<IUserData> GetAllUserData();

        /// <summary>
        /// set the storage address of a userdata.
        /// </summary>
        void SetStorage(IUserData data, DBAddress address);

        /// <summary>
        /// register userdata to system.
        /// </summary>
        bool AddUserData(IUserData data);

        /// <summary>
        /// remove the userdata from system.
        /// </summary>
        bool RemoveUserData(string name);

        /// <summary>
        /// add field to a userdata.
        /// </summary>
        bool AddField(IUserData data, string fieldName);

        /// <summary>
        /// remove the field from userdata.
        /// </summary>
        bool RemoveField(IUserData data, string fieldName);

        /// <summary>
        /// update field name.
        /// </summary>
        bool RenameField(IUserData data, string fieldName, string newName);
    }
}
