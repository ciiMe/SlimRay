
using SlimRay.App;

namespace SlimRay.UserData
{
    public interface IUserDataLoader : IDataLoaderApp<IUserData>
    {
        IUserData Get(string name);
    }
}
