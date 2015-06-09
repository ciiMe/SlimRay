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
            IAddinApp[] apps = aloader.LoadAll();

            foreach (IAddinApp app in apps)
            {
                //call execute to init simulator
                app.Execute("init..");

                if (!(app is IAddinApp))
                {
                    continue;
                }

                IAddinApp addin = app as IAddinApp;
                AppGate.Instance.RegisterAddinApp(addin);
            }
        }         
    }
}
