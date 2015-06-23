using SlimRay.App.Loaders;

namespace SlimRay.App
{
    public static class SystemApps
    {
        public static IUserDataHelperApp GetUserDataHelper()
        {
            return AppGate.Instance.Get(AppKeys.UserDataAdapter) as IUserDataHelperApp;
        }
    }
}
