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
            IAddinApp[] apps = aloader.LoadAll();

            foreach (IAddinApp app in apps)
            {
                app.Execute("init..");
            }
        }
    }
}
