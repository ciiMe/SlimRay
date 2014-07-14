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

            var de = _manager.GetEntity(SysData.Users,
                SysData.Users.LoginName.Expression.Equal(userName));

            if (de.ValueInt32(SysData.Users.Status) != (int)UserStatus.Valid)
            {
                errMsg = "User state is not valid.";
                return false;
            }

            if (de.ValueString(SysData.Users.LoginPassword) != password)
            {
                errMsg = "Password is wrong.";
                return false;
            }

            return true;
        }
    }
}
