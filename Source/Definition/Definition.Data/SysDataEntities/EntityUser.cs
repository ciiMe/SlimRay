using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.Data;
using SlimRay.Data.Entity;

namespace SlimRay.UI.DesignTime.Data.SysDataEntities
{
    public class EntityUser : SRData
    {
        public IField ID, UserName, LoginName, LoginPassword, Status;

        public EntityUser()
            : base("User", "Users that can access the system.")
        {
            initFields();
        }

        private void initFields()
        {
            ID = new SRField("ID", FieldDataType.UnInt32);
            AddField(ID);

            UserName = new SRField("Name", FieldDataType.String);
            AddField(UserName);

            LoginName = new SRField("LoginName", FieldDataType.String);
            AddField(LoginName);

            LoginPassword = new SRField("LoginPassword", FieldDataType.String);
            AddField(LoginPassword);

            Status = new SRField("StatusID", FieldDataType.Emun);
            AddField(Status);
        }
    }
}
