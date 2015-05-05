
using SlimRay.UserData.Entities;

namespace SlimRay.UserData
{
    public interface IUserDataLoader
    {
        IUserData[] Get();
        IUserData Get(string name);
    }
}
