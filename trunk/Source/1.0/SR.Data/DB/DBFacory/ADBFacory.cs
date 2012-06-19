using System.Data.Common;

using SR.Base.Types;

namespace SR.Data.DB.DBFacory
{
    public abstract class ADBFacory : IDBFactory
    {
        /// <summary>
        /// 此部件所使用的连接信息
        /// </summary>
        protected ValidDBConnectionType _ConnectionType;

        public abstract DbConnection NewDBConnection(IConnectionInfo ci);
        public abstract DbDataAdapter NewDBDataAdapter();
        public abstract DbCommand NewDBCommand();
        public abstract DbParameter NewDBParameter();

        public ADBFacory()
        {

        }

        public bool IsMyType(IConnectionInfo ci)
        {
            return
                null != ci && ci.ConnectionType == _ConnectionType;
        }

        public ValidDBConnectionType ConnectionType
        {
            get { return _ConnectionType; }
        }
    }
}
