using SlimRay.App;
using SlimRay.Cache;

namespace SlimRay.App
{
    /*
     * App Pool is only used in internal,
     * because there will be more and more apps are registered here,
     * a high level manager should be the only access to this class.
     */
    internal class AppPool
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

        public bool Unregister(string key)
        {
            return _apps.Remove(key);
        }
    }
}
