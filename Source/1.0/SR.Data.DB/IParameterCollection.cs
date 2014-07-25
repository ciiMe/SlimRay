using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Common;
namespace SR.Data.DB
{
    public interface IParameterCollection
    {
        List<KeyValuePair<string, object>> Parameters { get; }
        DbParameter[] GetParameters();

        void AddParameter(string name, string value);
        void AddParameter(string name, int value);
    }
}
