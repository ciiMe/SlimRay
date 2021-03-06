﻿using SlimRay.UserData;
using SlimRay.UserData.Container;

namespace SlimRay.Store
{
    /*
     * a strore saves and loads data,
     * it does not save or load data directly,
     * another manager will be called to do save and load(R/W).
     */
    public interface IStore
    {
        /// <summary>
        /// set storage type for all data.
        /// </summary>
        void SetStorageType(StorageType stype);

        /// <summary>
        /// set storage type for specific data.
        /// </summary>
        void AssignStorageType(IUserData data, StorageAddress address);

        void InsertNewRecord(IDataContainer entity);
        //void UpdateRecord(IDataEntity entity);
        //void RemoveRecord(IDataEntity entity);

        IDataContainer LoadRecord(string dataName, string key);
        IDataContainer LoadRecord(Expression expression);
    }
}
