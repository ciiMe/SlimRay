using System;

namespace SlimRay.App
{
    class AddinDependenceHelper : IAddinDependenceHelper
    {
        public IAPP[] GetRegisterableApps(IAPP app)
        {
            return new IAPP[] { app };
        }

        public IAPP[] GetRegisterableApps(IAPP[] apps)
        {
            return apps;
        }
    }
}
