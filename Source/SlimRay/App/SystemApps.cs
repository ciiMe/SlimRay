using SlimRay.UserData;

namespace SlimRay.App
{
    public static class SystemApps
    {
        public static IUserDataHelper GetUserDataHelper()
        {
            return AppGate.Instance.Get(AppKeys.UserDataAdapter) as IUserDataHelper;
        }
    }
}
