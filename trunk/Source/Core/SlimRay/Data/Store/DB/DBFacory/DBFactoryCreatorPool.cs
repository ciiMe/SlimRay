using System;
using System.Collections.Generic;

namespace SlimRay.Data.DB.DBFacory
{
    /*
     * 传入连接信息，生成FacotyItem，可以在这里扩展以支持更多类型的数据库。
     * 
     * 内部实现：将所有的FactoryCreator放入队列即刻完成对于多种数据库的支持。
     * 
     * 之所以这样设计，是考虑到不是将所有支持的数据库Factory都放入队列中，谁能用就用谁；
     * 而是将Factory设计成被使用的工具，需要的时候才加载。
     * 
     * 这样不会将冗余的对象加入数据库操作池。
     * 
     * 如果调用数据库操作的时候发现系统没有数据库实例，
     * 系统初始化一个sql2000的实例支持数据库操作。
     */
    /// <summary>
    /// 根据传入的ConnectionInfo来生成DBFactory
    /// </summary>
    public class DBFactoryCreatorPool
    {
        private List<IDBFactoryCreator> _DBFactoryCreatorItems;

        public DBFactoryCreatorPool()
        {
            _DBFactoryCreatorItems = new List<IDBFactoryCreator>();
        }

        /// <summary>
        /// 检查当前池中同ConnectionType的DBFactoryCreator是否存在。
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        private bool _IsDBFactoryCreatroExists(IDBFactoryCreator fc)
        {
            foreach (ADBFactoryCreator c in _DBFactoryCreatorItems)
            {
                if (c.ConnectionType == fc.ConnectionType)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddDBFactoryCreator(IDBFactoryCreator fc)
        {
            if (_IsDBFactoryCreatroExists(fc))
            {
                return;
            }

            _DBFactoryCreatorItems.Add(fc);
        }

        /// <summary>
        /// 遍历可以支持的FactoryCreator，生成一个Factory
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public IDBFactory CreateNewFactory(ValidDBConnectionType ct)
        {
            foreach (IDBFactoryCreator fc in _DBFactoryCreatorItems)
            {
                if (fc.ConnectionType == ct)
                {
                    return fc.CreateNewFactory();
                }
            }

            return null;
        }

        private static DBFactoryCreatorPool __Instance;
        public static DBFactoryCreatorPool Instance
        {
            get
            {
                if (__Instance == null)
                {
                    __Instance = new DBFactoryCreatorPool();
                }

                return __Instance;
            }
        }
    }
}
