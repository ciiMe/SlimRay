using SlimRay.App;
using SlimRay.Cache;
using SlimRay.Simulator;

namespace SlimRay.Internal
{
    public class AppPool
    {
        private static AppPool _instance = new AppPool();

        public static AppPool Instance
        {
            get { return AppPool._instance; }
        }

        private MemoryCache<IApp> _apps;
        private int _validSeconds;

        public int ValidSeconds
        {
            get { return _validSeconds; }
            set { _validSeconds = value; }
        }

        public AppPool()
        {
            _validSeconds = 600;
            _apps = new MemoryCache<IApp>();

            registerSystemApps();
        }

        private void registerSystemApps()
        {
            AppUserDataLoader app = new AppUserDataLoader();
            Register(app);
        }

        public IApp Get(string key)
        {
            return _apps.Get(key);
        }

        public bool Exists(string key)
        {
            return _apps.Exists(key);
        }

        public bool Register(IApp app)
        {
            return _apps.Add(app.SerialKey, app);
        }

        public bool UnRegister(string key)
        {
            return _apps.Remove(key);
        }
    }
}
