using System.Collections.Generic;

namespace SlimRay.Data.Store
{
    public sealed class StorageAddress
    {
        private StorageType _type;
        private string _address;
        private List<KeyValuePair<string, string>> _parameters;

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

        public List<KeyValuePair<string, string>> Parameters
        {
            get { return _parameters; }
        }

        public StorageAddress()
        {
            _type = StorageType.FollowSystem;
            _address = "";
            _parameters = new List<KeyValuePair<string, string>>();
        }

        public bool IsParameterExists(string name)
        {
            return IndexOf(name) >= 0;
        }

        /// <summary>
        /// get index of name. return -1 when not exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IndexOf(string name)
        {
            name = name.ToLower().Trim();

            for (int i = 0; i < _parameters.Count; i++)
            {
                if (_parameters[i].Key.ToLower() == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void SetParameterValue(string name, string value)
        {
            name = name.Trim();
            int i = IndexOf(name);

            if (i >= 0)
            {
                _parameters[i] = new KeyValuePair<string, string>(name, value);
            }
            else
            {
                _parameters.Add(new KeyValuePair<string, string>(name, value));
            }
        }

        public void ClearParameters()
        {
            _parameters.Clear();
        }

        public void RemoveParameter(string name)
        {
            int i = IndexOf(name);

            if (i >= 0)
            {
                _parameters.RemoveAt(i);
            }
        }
    }
}
