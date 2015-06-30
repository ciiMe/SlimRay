using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimRay.App;

namespace SlimRay.Designer
{
    internal class AppInitializer
    {
        public static void Init()
        {
            AddinLoader aloader = new AddinLoader();
            IAPP[] apps = aloader.Load();

            foreach (IAPP app in apps)
            {
                //call execute to init simulator
                app.Initialize("");

                if (!(app is IAPP))
                {
                    continue;
                }

                IAPP addin = app as IAPP;
                AppGate.Instance.RegisterAddinApp(addin);
            }
        }
    }
}
