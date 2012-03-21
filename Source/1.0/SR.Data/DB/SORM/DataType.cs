using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DB.SORM
{   
    /// <summary>
    /// 定义用户数据的数据类型
    /// </summary>
    public enum UserDataType
    {
        UnKnown = 0,
        Int = 101,
        String = 201,
        Boolean = 301
    }


    public struct BaseDataType 
    {
        UserDataType InnerType;
        UserDataType OuterType;
    }

    public struct Field
    {
        BaseDataType DataType;
        string DBFieldName;
    } 

}
