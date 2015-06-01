using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SlimRay.App
{
    internal class AddinLoader : IAddinLoader
    {
        public void test()
        {
            var plugindir = new DirectoryInfo(".\\Addins");


            foreach (var filesInPlugin in plugindir.GetFiles())
            {
                if (filesInPlugin.Extension.ToLower() != ".dll")
                {
                    continue;
                }

                Assembly dllFromPlugin = Assembly.LoadFile(filesInPlugin.FullName);
                foreach (var dllModule in dllFromPlugin.GetLoadedModules())
                {
                    foreach (var typeDefinedInModule in dllModule.GetTypes())
                    {
                        //if (typeDefinedInModule.GetInterfaces().Contains(typeof(gp.IInterface)))
                        {
                            if (typeDefinedInModule.IsClass)
                            {
                                //var itemGet = System.Activator.CreateInstance(typeDefinedInModule) as gp.IInterface;
                            }
                        }
                    }
                }
            }
        }

        public IAddinApp Load(string filename)
        {
            throw new System.NotImplementedException();
        }

        public void Unload(IAddinApp app)
        {
            throw new System.NotImplementedException();
        }
    }
}
