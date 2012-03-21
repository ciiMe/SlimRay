
using System;
using System.Collections.Generic;

using System.Data.Common;

/*
 * the factory pool
 * 
 * item:
 *      is designed as ST mode,without destory now..
 *      auto created when request db command by the ConnectionInfo
 * 
 */

namespace SR.Data.DB.DBFacory
{
    [Serializable]
    public class DBFacoryPool : IDBFactoryItem
    {
        /// <summary>
        /// 委托，操作FactoryItem来生成相应的对象。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="ci"></param>
        /// <returns></returns>
        private delegate object DoNew(IDBFactoryItem item, IConnectionInfo ci);
        
        /// <summary>
        /// 池中的对象列表
        /// </summary>
        private List<IDBFactoryItem> _Items;

        public DBFacoryPool()
        {
            _Items = new List<IDBFactoryItem>();
        }

        private bool _Exists(IConnectionInfo ci)
        {
            string s = ci.ConnectionString.ToUpper();

            foreach (IDBFactoryItem item in _Items)
            {
                if (item.ConnectionInfo.ConnectionString.ToUpper() == s)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 将该类型的连接放入池中。默认检查存在性，不会将连接字符串相同的对象重复放入。
        /// </summary>
        /// <param name="ci">连接信息</param>
        /// <returns></returns>
        public bool AddByConnectionInfo(IConnectionInfo ci)
        {
            if (_Exists(ci))
            {
                return true;
            }

            //create by factory
            IDBFactoryItem i = DBFactoryItemMap.NewInstance(ci);

            if (null == i)
            {
                return false;
            }

            _Items.Add(i);

            return true;
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

        public void RemoveAt(int index)
        {
            _Items.RemoveAt(index);
        }

        /// <summary>
        /// get item in pool,
        /// create new if not exists.
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public int GetItemIndex(IConnectionInfo ci)
        {
            // if ci is null,return 0 as a default ItemIndex
            if (null == ci)
            {
                if (_Items.Count == 0)
                {
                    return -1;
                }

                return 0;
            }

            //not null: get from Pool items
            for (int i = 0; i < _Items.Count; i++)
            {
                if (_Items[i].IsMyType(ci))
                {
                    return i;
                }
            }

            //if not find ,create it.
            if (AddByConnectionInfo(ci))
            {
                return _Items.Count - 1;
            }

            return -1;
        }

        #region interface method

        #region __do new...

        private object _DoNewConn(IDBFactoryItem i, IConnectionInfo ci)
        {
            return i.NewDBConnection(ci);
        }

        private object _DoNewAdpt(IDBFactoryItem i, IConnectionInfo ci)
        {
            return i.NewDBDataAdapter(ci);
        }

        private object _DoNewPar(IDBFactoryItem i, IConnectionInfo ci)
        {
            return i.NewDBParameter(ci);
        }

        private object _DoNewCmd(IDBFactoryItem i, IConnectionInfo ci)
        {
            return i.NewDBCommand(ci);
        }

        private object _CallDoNew(IConnectionInfo ci, DoNew d)
        {
            int i = GetItemIndex(ci);

            if (i < 0)
            {
                return null;
            }

            return d(_Items[i], _Items[i].ConnectionInfo);
        }

        #endregion

        /// <summary>
        /// 根据传入的数据库配置，创建一个打开的Connection
        /// </summary>
        /// <returns></returns>
        public DbConnection NewDBConnection(IConnectionInfo ci)
        {
            return _CallDoNew(ci, _DoNewConn) as DbConnection;
        }

        /// <summary>
        /// 根据传入的数据库配置，创建一个空的Adapter
        /// </summary>
        /// <returns></returns>
        public DbDataAdapter NewDBDataAdapter(IConnectionInfo ci)
        {
            return _CallDoNew(ci, _DoNewAdpt) as DbDataAdapter;
        }

        /// <summary>
        /// 根据特定的数据库连接信息，创建新的Parameter
        /// </summary>
        /// <param name="cInfo">数据库连接信息</param>
        /// <returns></returns>
        public DbParameter NewDBParameter(IConnectionInfo ci)
        {
            return _CallDoNew(ci, _DoNewPar) as DbParameter;
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
            if (_Items.Count == 0)
            {
                return null;
            }

            return NewDBParameter(_Items[0].ConnectionInfo, name, val);
        }

        public IConnectionInfo ConnectionInfo
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 根据传入的数据库配置，创建一个空的Command
        /// </summary>
        /// <returns></returns>
        public DbCommand NewDBCommand(IConnectionInfo ci)
        {
            return _CallDoNew(ci, _DoNewCmd) as DbCommand;
        }

        public bool IsMyType(IConnectionInfo ci)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
