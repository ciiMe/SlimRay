using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Store.StorageAddresses
{
    public class MSSQLServer : StorageAddress
    {
        private string _userName;
        private string _password;
        
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public MSSQLServer()
        {
            _type = StorageType.MSSQLServer;
        }

        public new StorageType Type
        {
            get { return _type; }
        }
    }
}
