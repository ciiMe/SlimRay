﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SlimRay.Data.Manager;

using SlimRay.Definition.Data.SysDataEntities;

namespace SlimRay.Definition.Data.SysDataManager
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

            var expr = SysData.Users.LoginName.Equal(userName);

            var de = _manager.GetEntity(SysData.Users, expr);

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

        public EntityUser Load(string userName)
        {
            var expr = SysData.Users.LoginName.Equal(userName);
            return _manager.GetEntity(SysData.Users, expr) as EntityUser;
        }
    }
}