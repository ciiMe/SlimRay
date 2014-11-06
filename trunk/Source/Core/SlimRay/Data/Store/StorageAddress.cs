using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Store
{
    public sealed class StorageAddress
    {
        private StorageType _type;
        private string _address;
        private KeyValuePair<string, string> _parameters;

        public StorageType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public KeyValuePair<string, string> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public StorageAddress()
        {
            _type = StorageType.FollowSystem;
            _address = "";
            _parameters = new KeyValuePair<string, string>();
        }
    }
}
