﻿using SlimRay.App.Loaders;
using SlimRay.UserData;

namespace SlimRay.App
{
    /* a portal to get all public apps,
     * it also provide portal to simulator apps, 
     * then you can write many apps to set a virtual environment.
     */
    public class AppGate : IGate
    {
        public static IUserDataLoader GetUserDataLoader()
        {
            return AppPool.Instance.Get(AppKeys.UserDataLoader) as IUserDataLoader;
        }

        public static IBindConfigLoader GetUIBindingLoader()
        {
            return AppPool.Instance.Get(AppKeys.BindConfigLoader) as IBindConfigLoader;
        }

        public static void RegisterAddinApp(IAddinApp app)
        {
            AppPool.Instance.Register(app);
        }

        public static void UnregisterAddinApp(IAddinApp app)
        {
            AppPool.Instance.Unregister(app.GetKey());
        }

        public static void RegisterSimulatorApp(ISimulatorApp app)
        {
            AppPool.Instance.Register(app);
        }

        public static void UnregisterSimulaterApp(ISimulatorApp app)
        {
            AppPool.Instance.Unregister(app.GetKey());
        }
    }
}