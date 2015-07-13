using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.DB;
using SlimRay.App;

namespace SlimRay.Test.DB
{
    public class AppConstant
    {
        public const string MainDBType = "SlimRay.DB.Helpers.MSSQLHelper";
        public const string ConnectString = "Server=lv-pc;Database=book;User Id=sa;Password=root;";

        public static DBAddress DBAccessParameters;

        public static DBAddress GetDefaultDBAddress()
        {
            return new DBAddress
            {
                DataKey = MainDBType,
                Address = ConnectString
            };
        }

        public static void InitApps()
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
