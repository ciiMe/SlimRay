using System.Data.Common;

namespace SR.Data.DB.DBFacory
{
    public abstract class ADBFacoryItem : IDBFactoryItem
    {
        /// <summary>
        /// 此部件所使用的连接信息
        /// </summary>
        protected IConnectionInfo _ConnectionInfo;

        public abstract DbConnection NewDBConnection(IConnectionInfo ci);
        public abstract DbDataAdapter NewDBDataAdapter(IConnectionInfo ci);
        public abstract DbCommand NewDBCommand(IConnectionInfo ci);
        public abstract DbParameter NewDBParameter(IConnectionInfo ci);

        public ADBFacoryItem()
        {

        }

        public bool IsMyType(IConnectionInfo ci)
        {
            return 
                null != ci 
                && ci.ConnectionType == _ConnectionInfo.ConnectionType 
                && ci.ConnectionString.ToUpper() == _ConnectionInfo.ConnectionString.ToUpper();
        }

        public IConnectionInfo ConnectionInfo
        {
            get { return _ConnectionInfo; }
        }
    }
}
