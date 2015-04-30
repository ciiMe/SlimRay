using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.UserData;

namespace SlimRay.Designer.DataAccess
{
    public interface IStore
    {
        IUserData[] Load();
        IUserData Load(int id);
        IUserData Load(string name);

        bool Update(IUserData data);
        bool Remove(IUserData data);
    }
}
