using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SR.Data.Manager;

namespace SR.UI.DesignTime.Data.SysDataManager
{
    public class UserManager
    {
        private DataManager _manager;

        public UserManager()
        {
            _manager = new DataManager();
        }

        public bool IsPasswordMatch(string userName, string password, out string errMsg)
        {
            errMsg = "";

            DataTable dt = _manager.GetDataTable(SysData.Users,
                SysData.Users.LoginName.Expression.Equal(userName));

            return true;
        }
    }
}
