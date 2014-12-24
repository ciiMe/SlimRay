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

        public IData NewSimpleData(string name)
        {
            return new Data(name);
        }

        public IField NewSimpleField(string name, FieldType type)
        {
            return new Field(name, type);
        }
    }
}
