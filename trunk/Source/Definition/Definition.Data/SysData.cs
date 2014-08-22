using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SlimRay.Data;

namespace SlimRay.Definition.Data
{
    public class SysData
    {
        public static SysDataEntities.EntityUser Users;
        public static SysDataEntities.EntityUserStatus UserStatus;

        // todo:should be loaded from configruation file.
        public static void Init()
        {
            Users = new SysDataEntities.EntityUser();

            UserStatus = new SysDataEntities.EntityUserStatus();
            Users.Status.Link(UserStatus, FieldLinkRelation.External);
        }


    }
}
