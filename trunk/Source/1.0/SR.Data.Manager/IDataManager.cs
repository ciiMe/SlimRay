using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SR.Data;

namespace SR.Data.Manager
{
    /*
     * The interface is designed for user-ui,
     * any data is input as string,
     * so,only string value is used for compareing.
     */
    public interface IDataManager
    {
        bool ValueCompare(IField field, DataCompareType ct,DataCompareMethod cm, string compareValue);
        bool IsType(string data, IDataType type);

        //IData Load(...from where??)
    }
}
