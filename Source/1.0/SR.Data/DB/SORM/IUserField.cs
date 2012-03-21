using System;
using SR.Base.Interface;
using SR.Base.Abstract;

namespace SR.Data.DB.SORM
{
    /// <summary>
    /// 表示用户数据字段
    /// </summary>
    public interface IUserField : IID<int>, IName, IDescription, IIndex, IValid
    {
        UserDataType DataType { get; set; }
    }
}
