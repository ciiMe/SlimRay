using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SlimRay.App
{
    public class AddinLoader : IAddinLoader
    {
        public IAPP[] Load(bool includeDependence = false)
        {
            List<IAPP> addins = new List<IAPP>();

            var dir = new DirectoryInfo(".\\Addins");
            Type tAddin = typeof(IAPP);

            foreach (var file in dir.GetFiles())
            {
                if (file.Extension.ToLower() != ".dll")
                {
                    continue;
                }

                Assembly dll = Assembly.LoadFile(file.FullName);
                foreach (var dllModule in dll.GetLoadedModules())
                {
                    foreach (var t in dllModule.GetTypes())
                    {
                        if (t.GetInterfaces().Contains(tAddin))
                        {
                            var addin = Activator.CreateInstance(t) as IAPP;

                            if (addin == null)
                            {
                                //todo: log load fail..
                                continue;
                            }
                            addin.Initialize("");
                            addins.Add(addin);
                        }
                    }
                }
            }

            return includeDependence ? withDependenceApps(addins.ToArray()) : addins.ToArray();
        }

        public IAPP[] Load(string addinFileName, bool includeDependence = false)
        {
            FileInfo file = new FileInfo(addinFileName);
            Type tAddin = typeof(IAPP);

            List<IAPP> addins = new List<IAPP>();

            if (!file.Exists)
            {
                return addins.ToArray();
            }

            if (file.Extension.ToLower() != ".dll")
            {
                return addins.ToArray();
            }

            Assembly dll = Assembly.LoadFile(file.FullName);
            foreach (var dllModule in dll.GetLoadedModules())
            {
                foreach (var t in dllModule.GetTypes())
                {
                    if (t.GetInterfaces().Contains(tAddin))
                    {
                        var addin = System.Activator.CreateInstance(t) as IAPP;

                        if (addin == null)
                        {
                            //todo: log load fail..
                            continue;
                        }
                        addin.Initialize("");
                        addins.Add(addin);
                    }
                }
            }

            return includeDependence ? withDependenceApps(addins.ToArray()) : addins.ToArray();
        }

        private IAPP[] withDependenceApps(IAPP[] apps)
        {
            AddinDependenceHelper helper = new AddinDependenceHelper();
            return helper.GetRegisterableApps(apps);
        }
    }
}
