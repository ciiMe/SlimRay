using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Factories
{
    public class SimpleDataFactory
    {
        private static SimpleDataFactory _instance;
        public static SimpleDataFactory Instance
        {
            get
            {
                return _instance == null ? _instance = new SimpleDataFactory() : _instance;
            }
        }

        public ISimpleData NewSimpleData(string name)
        {
            return new SimpleData(name);
        }
    }
}
