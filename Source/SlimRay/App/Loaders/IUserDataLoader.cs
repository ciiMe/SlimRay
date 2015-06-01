using SlimRay.App;
using SlimRay.UserData;

namespace SlimRay.App.Loaders
{
    public interface IUserDataLoader : ILoaderApp<IUserData>
    {
        IUserData Get(string name);
    }
}
