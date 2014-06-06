
using System;
using System.Collections.Generic;

using System.Data.Common;

/*
 * the factory pool
 * 
 * 每一个连接信息都被保存，以支持生产各种类型的数据库操作部件
 * 
 * 每一个类型的数据库工厂只保持一个实例
 * 
 * 对于调用者，连接信息是透明的，只需要使用相应连接信息的配置进行数据库操作，不必关心内部如何维护
 * 
 * 
 * 如果这个连接字符串没有，那么调用ItemMap生产一个。
 * 
 * item:
 *      is designed as ST mode,without destory now..
 *      auto created when request db command by the ConnectionInfo
 * 
 */

namespace SR.Data.DB.DBFacory
{
    [Serializable]
    public class DBFacoryPool
    {
        /// <summary>
        /// 委托，操作FactoryItem来生成相应的对象。
        /// 将操作放到外部，查询和校验放在一起。以完成同一对象不同功能的基础代码的聚合。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="ci"></param>
        /// <returns></returns>
        private delegate object DoNew(IDBFactory item, IConnectionInfo ci);

        /// <summary>
        /// 池中的对象列表
        /// </summary>
        private List<IDBFactory> _FactoryItems;

        /// <summary>
        /// 保存的连接信息列表
        /// </summary>
        private List<IConnectionInfo> _ConnectionInfoItems;

        private int __DefaultConnectionInfoIndex;

        /// <summary>
        /// 管理默认连接限定其值在：-1或者正常范围。
        /// </summary>
        private int _DefaultConnectionInfoIndex
        {
            get
            {
                if (_ConnectionInfoItems.Count == 0)
                {
                    __DefaultConnectionInfoIndex = -1;
                }
                else if (__DefaultConnectionInfoIndex < 0 || __DefaultConnectionInfoIndex >= _ConnectionInfoItems.Count)
                {
                    __DefaultConnectionInfoIndex = 0;
                }

                return __DefaultConnectionInfoIndex;
            }
        }

        private IConnectionInfo DefaultConnectionInfo
        {
            get
            {
                if (_DefaultConnectionInfoIndex < 0)
                {
                    return null;
                }

                return _ConnectionInfoItems[__DefaultConnectionInfoIndex];
            }
            set
            {
                __DefaultConnectionInfoIndex = _GetConnectionInfoIndex(value);
            }
        }

        public DBFacoryPool()
        {
            _FactoryItems = new List<IDBFactory>();

            _ConnectionInfoItems = new List<IConnectionInfo>();

            __DefaultConnectionInfoIndex = -1;
        }

        private bool _IsConnInfoExists(IConnectionInfo ci)
        {
            foreach (IConnectionInfo connInfo in _ConnectionInfoItems)
            {
                if (SR.Utils.Strings.CharCompare(connInfo.ConnectionString, ci.ConnectionString))
                {
                    return true;
                }
            }

            return false;
        }

        private bool _IsFactoryExists(IConnectionInfo ci)
        {
            foreach (IDBFactory item in _FactoryItems)
            {
                if (item.ConnectionType == ci.ConnectionType)
                {
                    return true;
                }
            }

            return false;
        }

        private bool _AddNewFactory(IConnectionInfo ci)
        {
            IDBFactory i = DBFactoryCreatorPool.Instance.CreateNewFactory(ci.ConnectionType);

            if (null == i)
            {
                return false;
            }

            _FactoryItems.Add(i);

            return true;
        }

        /// <summary>
        /// 将该连接信息配置加入配置列表。会检查存在性，不会将连接字符串相同的连接信息重复放入。
        /// </summary>
        /// <param name="ci">连接信息</param>
        /// <returns></returns>
        public bool AddConnectionInfo(IConnectionInfo ci)
        {
            if (_IsConnInfoExists(ci))
            {
                return true;
            }

            if (!_AddNewFactory(ci))
            {
                return false;
            }

            _ConnectionInfoItems.Add(ci);

            return true;
        }

        /// <summary>
        /// 查询同ConnectionType的连接信息的总数
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        private int _GetConnectionTypeCount(ValidDBConnectionType ct)
        {
            int i = 0;

            foreach (IDBFactory item in _FactoryItems)
            {
                if (item.ConnectionType == ct)
                {
                    i++;
                }
            }

            return i;
        }

        private int _GetFactoryIndex(ValidDBConnectionType ct)
        {
            for (int i = 0; i < _FactoryItems.Count; i++)
            {
                if (_FactoryItems[i].ConnectionType == ct)
                {
                    return i;
                }
            }

            return -1;
        }

        private int _GetConnectionInfoIndex(IConnectionInfo ci)
        {
            for (int i = 0; i < _ConnectionInfoItems.Count; i++)
            {
                if (SR.Utils.Strings.CharCompare(ci.ConnectionString, _ConnectionInfoItems[i].ConnectionString))
                {
                    return i;
                }
            }
            return -1;
        }

        private static DBFacoryPool _Instance;
        public static DBFacoryPool Instance
        {
            set { _Instance = value; }
            get
            {
                if (null == _Instance)
                {
                    _Instance = new DBFacoryPool();
                }
                return _Instance;
            }
        }

        public void RemoveConnectionInfoAt(int index)
        {
            if (index < 0 || index >= _ConnectionInfoItems.Count)
            {
                return;
            }

            int td = _GetConnectionTypeCount(_ConnectionInfoItems[index].ConnectionType);

            if (td == 0)
            {
                return;
            }
            else if (td == 1)
            {
                int i = _GetFactoryIndex(_ConnectionInfoItems[index].ConnectionType);

                _FactoryItems.RemoveAt(i);
                _ConnectionInfoItems.RemoveAt(index);
            }
            else
            {
                _ConnectionInfoItems.RemoveAt(index);
            }
        }

        /// <summary>
        /// get item in pool,
        /// create new if not exists.
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public int GetFactoryItemIndex(IConnectionInfo ci, bool createIfNotFound = false)
        {
            // if ci is null,return 0 as a default ItemIndex
            if (null == ci)
            {
                return _FactoryItems.Count == 0 ? -1 : _DefaultConnectionInfoIndex;
            }

            //not null: get from Pool items
            for (int i = 0; i < _FactoryItems.Count; i++)
            {
                if (_FactoryItems[i].IsMyType(ci))
                {
                    return i;
                }
            }

            //if not find ,create it.
            if (createIfNotFound)
            {
                return AddConnectionInfo(ci) ? _FactoryItems.Count - 1 : -1;
            }
            else
            {
                return -1;
            }
        }

        #region interface method

        #region __do new...

        private object _DoNewConn(IDBFactory i, IConnectionInfo ci)
        {
            return i.NewDBConnection(ci);
        }

        private object _DoNewAdpt(IDBFactory i, IConnectionInfo ci)
        {
            return i.NewDBDataAdapter();
        }

        private object _DoNewPar(IDBFactory i, IConnectionInfo ci)
        {
            return i.NewDBParameter();
        }

        private object _DoNewCmd(IDBFactory i, IConnectionInfo ci)
        {
            return i.NewDBCommand();
        }

        /*
         * 如果没有指定连接信息，那么按照默认的连接信息。
         * 
         * 如果指定了连接信息，那么调用此类型的工厂生产一份套件来操作数据库。
         */
        private object _DoNew_CallFacotyInPool(IConnectionInfo ci, DoNew d)
        {
            if (ci == null)
            {
                if (_DefaultConnectionInfoIndex < 0)
                {
                    return null;
                }

                return _FactoryItems.Count == 1 ?
                    d(_FactoryItems[0], _ConnectionInfoItems[__DefaultConnectionInfoIndex]) :
                    d(_FactoryItems[_GetFactoryIndex(_ConnectionInfoItems[__DefaultConnectionInfoIndex].ConnectionType)], _ConnectionInfoItems[__DefaultConnectionInfoIndex]);
            }
            else
            {
                int i = GetFactoryItemIndex(ci);
                return i >= 0 ? d(_FactoryItems[i], ci) : null;
            }
        }

        #endregion

        /// <summary>
        /// 根据传入的数据库配置，创建一个打开的Connection
        /// </summary>
        /// <returns></returns>
        public DbConnection NewDBConnection(IConnectionInfo ci)
        {
            return _DoNew_CallFacotyInPool(ci, _DoNewConn) as DbConnection;
        }

        /// <summary>
        /// 根据传入的数据库配置，创建一个空的Adapter
        /// </summary>
        /// <returns></returns>
        public DbDataAdapter NewDBDataAdapter(IConnectionInfo ci)
        {
            return _DoNew_CallFacotyInPool(ci, _DoNewAdpt) as DbDataAdapter;
        }

        /// <summary>
        /// 根据特定的数据库连接信息，创建新的Parameter
        /// </summary>
        /// <param name="cInfo">数据库连接信息</param>
        /// <returns></returns>
        public DbParameter NewDBParameter(IConnectionInfo ci)
        {
            return _DoNew_CallFacotyInPool(ci, _DoNewPar) as DbParameter;
        }

        /// <summary>
        /// 根据特定的数据库连接信息，创建新的Parameter
        /// </summary>
        /// <param name="cInfo">数据库连接信息</param>
        /// <param name="name">parameter名称</param>
        /// <param name="val">parameter值</param>
        /// <returns></returns>
        public DbParameter NewDBParameter(IConnectionInfo ci, string name, object val)
        {
            DbParameter p = NewDBParameter(ci);

            if (null != p)
            {
                p.ParameterName = name;
                p.Value = val;
            }

            return p;
        }

        /// <summary>
        /// 根据配置的数据库连接信息，创建新的Parameter
        /// </summary>
        /// <param name="name">parameter名称</param>
        /// <param name="val">parameter值</param>
        /// <returns></returns>
        public DbParameter NewDBParameter(string name, object val)
        {
            if (_FactoryItems.Count == 0)
            {
                return null;
            }

            return NewDBParameter(_ConnectionInfoItems[0], name, val);
        }

        public ValidDBConnectionType ConnectionType
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 根据传入的数据库配置，创建一个空的Command
        /// </summary>
        /// <returns></returns>
        public DbCommand NewDBCommand(IConnectionInfo ci)
        {
            return _DoNew_CallFacotyInPool(ci, _DoNewCmd) as DbCommand;
        }

        public bool IsMyType(IConnectionInfo ci)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
