﻿using System;
using System.Collections.Generic;

namespace SlimRay.Cache
{
    public class STMemoryCache : MemoryCache<object>
    {
        private static readonly STMemoryCache _instance = new STMemoryCache();
        public static STMemoryCache Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
