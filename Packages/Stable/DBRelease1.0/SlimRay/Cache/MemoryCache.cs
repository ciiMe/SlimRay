using System;
using System.Collections.Generic;

namespace SlimRay.Cache
{
    public class MemoryCache<ItemType> : ICache<ItemType>
    {
        private readonly object _resourceLock;
        private readonly Dictionary<string, CachedItem> _cachedData;

        private int _validSeconds;

        public int ValidSeconds
        {
            get { return _validSeconds; }
            set { _validSeconds = value; }
        }

        public MemoryCache()
        {
            _resourceLock = new object();
            _cachedData = new Dictionary<string, CachedItem>();

            _validSeconds = 600;
        }

        public ItemType Get(string key)
        {
            CachedItem item;
            bool success = _cachedData.TryGetValue(key, out item);

            if (!success)
            {
                item = new CachedItem
                {
                    Key = key,
                    Data = null,
                    UpdateTime = DateTime.Now
                };
            }

            //todo: no conversion is allowed, 
            //todo: so, I need to remove the conversion code in feature.
            return (ItemType)item.Data;
        }

        public bool Exists(string key)
        {
            return _cachedData.ContainsKey(key);
        }

        public bool Add(string key, ItemType data)
        {
            if (data == null || key == null || key == "")
            {
                return false;
            }

            lock (_resourceLock)
            {
                CachedItem item = new CachedItem
                {
                    Key = key,
                    Data = data,
                    UpdateTime = DateTime.Now
                };

                if (Exists(key))
                {
                    _cachedData.Remove(key);
                }

                _cachedData.Add(key, item);
                return true;
            }
        }

        public bool Remove(string key)
        {
            lock (_resourceLock)
            {
                if (!Exists(key))
                {
                    return true; ;
                }

                _cachedData.Remove(key);
                return true;
            }
        }
    }
}
