using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.UI.DesignTime.Data
{
    /// <summary>
    /// Define the levels for design time data.
    /// The level is used in the region of design project,
    /// to judge the importance of data.
    /// </summary>
    public enum DataLevel
    {
        System,
        Common,
        Optional
    }

    /// <summary>
    /// Defines the keys of all data.
    /// </summary>
    public enum DataKeys
    {
        User,
        UserStatus
    }
}
