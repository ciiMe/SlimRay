using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SlimRay.App
{
    public class AddinLoader : IAddinLoader
    {
        public IAddinApp[] LoadAll()
        {
            List<IAddinApp> addins = new List<IAddinApp>();

            var dir = new DirectoryInfo(".\\Addins");
            Type tAddin = typeof(IAddinApp);

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
                            var addin = System.Activator.CreateInstance(t) as IAddinApp;

                            if (addin == null)
                            {
                                //todo: log load fail..
                                continue;
                            }
                            addins.Add(addin);
                        }
                    }
                }
            }

            return addins.ToArray();
        }

        public void Unload(IAddinApp app)
        {
            throw new System.NotImplementedException();
        }


        public IAddinApp[] Load(string addinFileName)
        {
            FileInfo file = new FileInfo(addinFileName);
            Type tAddin = typeof(IAddinApp);

            List<IAddinApp> addins = new List<IAddinApp>();

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
                        var addin = System.Activator.CreateInstance(t) as IAddinApp;

                        if (addin == null)
                        {
                            //todo: log load fail..
                            continue;
                        }
                        addins.Add(addin);
                    }
                }
            }

            return addins.ToArray();
        }
    }
}
