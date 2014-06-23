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
            : base((int)DataKeys.UserStatus, (int)DataLevel.System, "UserStatus", "")
        {
            initFields();
        }

        private void initFields()
        {
            ID = new SRField(0, "ID", DataProvider.Instance.DataTypeEntities.SRInt);
            AddField(ID);

            StatusName = new SRField(0, "Name", DataProvider.Instance.DataTypeEntities.SRString);
            AddField(StatusName);
        }
    }
}
