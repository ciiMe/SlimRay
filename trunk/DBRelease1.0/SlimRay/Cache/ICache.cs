using System;

namespace SlimRay.Cache
{
    public interface ICache<TItemType>
    {
        /// <summary>
        /// how many seconds is data valid.
        /// null will be returned if overtime.
        /// </summary>
        int ValidSeconds { get; set; }

        TItemType Get(string key);
        bool Exists(string key);

        bool Add(string key, TItemType data);
        bool Remove(string key);
    }
}
