using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.DB
{
    public interface IRequest
    {
        void AddParameter(string key, object value);
        void RemoveParameter(string key);
        void ClearParameters();

        KeyValuePair<string, object>[] Parameters { get; }

        ExecutorParameters ExecutorParameter { get; set; }

        string Command { get; set; }

        int Timeout { get; set; }
    }
}
