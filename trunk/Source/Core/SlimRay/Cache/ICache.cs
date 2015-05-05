using System;

namespace SlimRay.Cache
{
    public interface ICache<ItemType>
    {
        /// <summary>
        /// how many seconds is data valid.
        /// null will be returned if overtime.
        /// </summary>
        int ValidSeconds { get; set; }

        ItemType Get(string key);
        bool Exists(string key);

        bool Add(string key, ItemType data);
        bool Remove(string key);
    }
}
