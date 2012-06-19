using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DB.DBFacory
{
    /// <summary>
    /// 工厂Map，根据连接信息创建工厂。
    /// </summary>
    public interface IDBFactoryCreator
    {
        /// <summary>
        /// 此Creator所支持的DBConnectionType
        /// </summary>
        ValidDBConnectionType ConnectionType { get; }

        /// <summary>
        /// 创建新的Factory
        /// </summary>
        /// <returns></returns>
        IDBFactory CreateNewFactory();

        /// <summary>
        /// 向服务注册此对象，只有注册了的对象才可以被系统调用。
        /// </summary>
        void RegCreator();
    }

    public abstract class ADBFactoryCreator : IDBFactoryCreator
    {
        protected ValidDBConnectionType _ConnectionType;

        public ValidDBConnectionType ConnectionType
        {
            get
            {
                return _ConnectionType;
            }
        }

        public ADBFactoryCreator(bool isAutoRegCreator = true)
        {
            if (isAutoRegCreator)
            {
                RegCreator();
            }
        }

        public abstract IDBFactory CreateNewFactory();

        public void RegCreator()
        {
            DBFactoryCreatorPool.Instance.AddDBFactoryCreator(this);
        }
    }
}
