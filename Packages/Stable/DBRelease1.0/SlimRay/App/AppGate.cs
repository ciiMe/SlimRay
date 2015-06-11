using SlimRay.App.Loaders;
using SlimRay.UserData;

namespace SlimRay.App
{
    /* a portal to get all public apps,
     * it also provide portal to simulator apps, 
     * then you can write many apps to set a virtual environment.
     */
    public class AppGate : IGate
    {
        private static AppGate _instance = new AppGate();
        public static AppGate Instance
        {
            get { return _instance; }
        }

        public IApp Get(string key)
        {
            return AppPool.Instance.Get(key);
        }

        public void Unload(string key)
        {
            throw new System.NotImplementedException();
        }

        public IApp CreateNew(string key)
        {
            throw new System.NotImplementedException();
        }

        public IUserDataLoader GetUserDataLoader()
        {
            return Get(AppKeys.UserDataLoader) as IUserDataLoader;
        }

        public IBindConfigLoader GetUIBindingLoader()
        {
            return Get(AppKeys.BindConfigLoader) as IBindConfigLoader;
        }

        public void RegisterAddinApp(IAddinApp app)
        {
            AppPool.Instance.Register(app);
        }

        public void UnregisterAddinApp(IAddinApp app)
        {
            AppPool.Instance.Unregister(app.GetKey());
        }

        public void RegisterSimulatorApp(ISimulatorApp app)
        {
            AppPool.Instance.Register(app);
        }

        public void UnregisterSimulaterApp(ISimulatorApp app)
        {
            AppPool.Instance.Unregister(app.GetKey());
        }
    }
}