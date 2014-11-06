﻿using System.Data.Common;

using SlimRay.Data.DB;

namespace SlimRay.Data.Store.DB.DBFacory
{
    /// <summary>
    /// 代表Factory池中的对象
    /// </summary>
    public interface IDBFactory
    {
        /// <summary>
        /// 该对象的数据库类型
        /// </summary>
        ValidDBConnectionType ConnectionType { get; }

        DbConnection NewDBConnection(IConnectionInfo ci);
        DbDataAdapter NewDBDataAdapter();
        DbCommand NewDBCommand();
        DbParameter NewDBParameter();

        /// <summary>
        /// 检查连接信息和本对象的匹配性。如果匹配，那么本对象可以执行该连接信息对象的数据库操作。
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        bool IsMyType(IConnectionInfo ci);
    }
}
