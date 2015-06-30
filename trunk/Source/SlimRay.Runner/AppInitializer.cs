using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimRay.App;

namespace SlimRay.Runner
{
    internal class AppInitializer
    {
        public static void Init()
        {
            AddinLoader aloader = new AddinLoader();
            IAPP[] apps = aloader.Load();

            foreach (IAPP app in apps)
            {
                app.Initialize("init..");
            }
        }
    }
}
