using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SlimRay.App;

namespace HtmlAnalyser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initAddins();

            Application.Run(new frmDemo());
        }

        private static void initAddins()
        {
            AddinLoader aloader = new AddinLoader();
            IApp[] apps = aloader.LoadAll();

            foreach (IApp app in apps)
            {
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
