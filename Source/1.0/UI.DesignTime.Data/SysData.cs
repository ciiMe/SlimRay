using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SR.Data;

namespace UI.DesignTime.Data
{
    public class SysData
    {
        public static IData User;

        public static void Init()
        {
            initUser();
        }

        private static void initUser()
        {
            User = new SRData((int)DataKeys.User, (int)DataLevel.System, "Users", "System users.");

            User.AddField(
                new SRField(0, "ID", DataProvider.Instance.GetDataType((int)DataTypeKeys.SRInt))
                    );
            User.AddField(
                new SRField(0, "Name", DataProvider.Instance.GetDataType((int)DataTypeKeys.SRString))
                    );
            User.AddField(
                new SRField(0, "LoginName", DataProvider.Instance.GetDataType((int)DataTypeKeys.SRString))
                    );
            User.AddField(
                new SRField(0, "LoginPassword", DataProvider.Instance.GetDataType((int)DataTypeKeys.SRString))
                    );
            User.AddField(
                new SRField(0, "Name", DataProvider.Instance.GetDataType((int)DataTypeKeys.SRString))
                    );
            User.AddField(
                new SRField(0, "Name", DataProvider.Instance.GetDataType((int)DataTypeKeys.SRString))
                    );

            //User.AddField(new SRField(0,"ID",)
        }
    }
}
