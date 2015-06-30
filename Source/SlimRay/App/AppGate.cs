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

        public IAPP Get(string key)
        {
            return AppPool.Instance.Get(key);
        }

        public void Unload(string key)
        {
            throw new System.NotImplementedException();
        }

        public IAPP CreateNew(string key)
        {
            throw new System.NotImplementedException();
        }

        public IBindConfigLoader GetUIBindingLoader()
        {
            return Get(AppKeys.BindConfigLoader) as IBindConfigLoader;
        }

        public void RegisterAddinApp(IAPP app)
        {
            AppPool.Instance.Register(app);
        }

        public void UnregisterAddinApp(IAPP app)
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