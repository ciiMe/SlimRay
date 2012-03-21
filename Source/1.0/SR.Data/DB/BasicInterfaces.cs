
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using SR.Base.Interface;

namespace SR.Data.DB
{

    public interface ISQLText
    {
        string GetSQLText();
    }

    public interface IParameters
    {
        List<KeyValuePair<string, object>> Parameters { get; }

        DbParameter[] GetParameters();
    }

    /// <summary>
    /// 数据库请求的类型
    /// </summary>
    public enum ExecuteCommandType
    {
        /// <summary>
        /// sql文本
        /// </summary>
        CommandText = 0,

        /// <summary>
        /// 存储过程
        /// </summary>
        StoredProc = 1
    }



}
