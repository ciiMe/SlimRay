using SlimRay.DB;
using SlimRay.App;

namespace SlimRay.UserData
{
    /*
     * this helper is not a must,
     * it only help to understand how does UserData be loaded and written.
     * this helper will call another to read/wirte system data.
     */
    public interface IUserDataHelper  
    {
        /// <summary>
        /// get the list of all userdata.
        /// </summary>
        IUserData[] GetData();

        /// <summary>
        /// get data by name.
        /// </summary>
        IUserData GetData(string dataName);

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
        bool UpdateData(string dataName, IUserData data);

        /// <summary>
        /// remove the userdata from system.
        /// </summary>
        bool RemoveData(string name);

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
        bool AddField(string dataName, IUserField fieldData);

        /// <summary>
        /// remove the field from userdata.
        /// </summary>
        bool RemoveField(string dataName, string fieldName);

        /// <summary>
        /// update field.
        /// </summary>
        bool UpdateField(string dataName, string fieldName, IUserField fieldData);
    }
}
