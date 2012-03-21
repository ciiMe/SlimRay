using System.Data.Common;

namespace SR.Data.DB.DBFacory
{
    /// <summary>
    /// 代表Factory池中的对象
    /// </summary>
    public interface IDBFactoryItem
    {
        /// <summary>
        /// 该对象的数据库类型
        /// </summary>
        IConnectionInfo ConnectionInfo { get; }

        DbConnection NewDBConnection(IConnectionInfo ci);
        DbDataAdapter NewDBDataAdapter(IConnectionInfo ci);
        DbCommand NewDBCommand(IConnectionInfo ci);
        DbParameter NewDBParameter(IConnectionInfo ci);

        /// <summary>
        /// 检查连接信息和本对象的匹配性。如果匹配，那么本对象可以执行该连接信息对象的数据库操作。
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        bool IsMyType(IConnectionInfo ci);
    }
}
