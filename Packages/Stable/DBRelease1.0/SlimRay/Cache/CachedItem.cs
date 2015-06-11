using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Cache
{
    public struct CachedItem
    {
        public string Key { get; set; }
        public object Data { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
