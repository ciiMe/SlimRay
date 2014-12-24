using System;
using System.Collections.Generic;
using System.Text;

namespace SlimRay.DB
{
    /// <summary>
    /// a request to data host,
    /// this class should be create by factory, 
    /// as the ExecutorParameter must be set by another object.
    /// </summary>
    public class Request : IRequest
    {
        private Dictionary<string, object> _parameters;

        private ExecutorParameters _executorParameters;

        private string _command;
        private int _timeout;

        public KeyValuePair<string, object>[] Parameters
        {
            get
            {
                KeyValuePair<string, object>[] r = new KeyValuePair<string, object>[_parameters.Count];

                lock (_parameters)
                {
                    using (var e = _parameters.GetEnumerator())
                    {
                        int i = 0;
                        while (e.MoveNext())
                        {
                            r[i] = new KeyValuePair<string, object>(e.Current.Key, e.Current.Value);
                            i++;
                        }
                    }
                }

                return r;
            }
        }

        public ExecutorParameters ExecutorParameter
        {
            get { return _executorParameters; }
            set { _executorParameters = value; }
        }

        public string Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public Request(ExecutorParameters ep)
        {
            _parameters = new Dictionary<string, object>();
            _command = "";
            _timeout = 20;

            _executorParameters = ep;
        }

        public void AddParameter(string key, object value)
        {
            _parameters.Add(key, value);
        }

        public void RemoveParameter(string key)
        {
            _parameters.Remove(key);
        }

        public void ClearParameters()
        {
            _parameters.Clear();
        }

    }
}
