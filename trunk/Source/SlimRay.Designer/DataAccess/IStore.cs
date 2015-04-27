using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.UserData;

namespace SlimRay.Designer.DataAccess
{
    public interface IStore
    {
        IData[] Load();
        IData Load(int id);
        IData Load(string name);

        bool Update(IData data);
        bool Remove(IData data);
    }
}
