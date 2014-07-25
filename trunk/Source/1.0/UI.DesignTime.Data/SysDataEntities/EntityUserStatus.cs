using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data;
using SR.Data.Entity;

namespace SR.UI.DesignTime.Data.SysDataEntities
{
    public class EntityUserStatus : SRData
    {
        public IField ID, StatusName;

        public EntityUserStatus()
            : base("UserStatus")
        {
            initFields();
        }

        private void initFields()
        {
            ID = new SRField("ID", FieldDataType.Int32);
            AddField(ID);

            StatusName = new SRField("Name", FieldDataType.String);
            AddField(StatusName);
        }
    }
}
