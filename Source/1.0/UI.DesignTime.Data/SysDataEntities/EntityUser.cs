using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data;
using SR.Data.Entity;

namespace SR.UI.DesignTime.Data.SysDataEntities
{
    public class EntityUser : SRData
    {
        public IField ID, UserName, LoginName, LoginPassword, Status;

        public EntityUser()
            : base((int)DataKeys.User, (int)DataLevel.System, "User", "Users that can access the system.")
        {
            initFields();
        }

        private void initFields()
        {
            ID = new SRField(0, "ID", DataProvider.Instance.DataTypeEntities.SRInt);
            AddField(ID);

            UserName = new SRField(0, "Name", DataProvider.Instance.DataTypeEntities.SRString);
            AddField(UserName);

            LoginName = new SRField(0, "LoginName", DataProvider.Instance.DataTypeEntities.SRString);
            AddField(LoginName);

            LoginPassword = new SRField(0, "LoginPassword", DataProvider.Instance.DataTypeEntities.SRString);
            AddField(LoginPassword);

            Status = new SRField(0, "StatusID", DataProvider.Instance.DataTypeEntities.SRInt);
            AddField(Status);
        }
    }
}
