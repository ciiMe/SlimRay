
namespace SlimRay.App
{
    /*
     * a key means a kind of app, the app with same key should provide the same function.
     * 
     * if app register by the key, it means the app is an app of this function.
     */
    public struct AppKeys
    {
        /// <summary>
        /// data loader app in AppPool.
        /// </summary>
        public const string UserDataLoader = "AppUserDataLoader";

        /// <summary>
        /// app that load userdata's data to container.
        /// </summary>
        public const string DataContainerLoader = "AppDataContainerLoader";

        /// <summary>
        /// app that load UI binding data.
        /// </summary>
        public const string BindConfigLoader = "AppBindingConfig";

        /// <summary>
        /// app that load all actions.
        /// </summary>
        public const string ActionLoader = "ActionLoader";
    }
}
