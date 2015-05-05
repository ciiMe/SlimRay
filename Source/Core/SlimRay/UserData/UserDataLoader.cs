using SlimRay.Internal;
using System;

namespace SlimRay.UserData
{
    /*
     * this loader does not load data itself, it call the app registered in AppPool to load data.
     * it will not be allowed to know who is the app, only get and use an app.
     */
    public class UserDataLoader : IUserDataLoader
    {
        private IUserDataLoader _loader;

        public UserDataLoader()
        {
            _loader = AppPool.Instance.Get(AppKeys.UserDataLoader) as IUserDataLoader;
        }

        public IUserData[] Get()
        {
            return _loader.Get();
        }

        public IUserData Get(string name)
        {
            return _loader.Get(name);
        }
    }
}
