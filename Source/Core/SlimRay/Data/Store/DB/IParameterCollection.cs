using System.Collections.Generic;
using System.Data.Common;

namespace SlimRay.Data.Store.DB
{
    public interface IParameterCollection
    {
        List<KeyValuePair<string, object>> Parameters { get; }
        DbParameter[] GetParameters();

        void AddParameter(string name, string value);
        void AddParameter(string name, int value);
    }
}
