using System.Collections.Generic;
 

namespace SR.Base.Interface
{
    /// <summary>
    /// 表示在队列中的对象
    /// </summary>
    public interface IIndex
    {
        /// <summary>
        /// 在队列中的序号
        /// </summary>
        int Index { get; }
    }

    /// <summary>
    /// 表示拥有ID的对象
    /// </summary>
    public interface IID<IDType>
    {
        IDType ID { get; }
    }

    public interface IName
    {
        string Name { get; set; }
    }

    /// <summary>
    /// 表示可以设置可用状态的对象
    /// </summary>
    public interface IValid
    {
        bool Valid { get; set; }
    }

    /// <summary>
    /// 记录初始值和当前值的对象
    /// </summary>
    public interface IChanged<DataType>
    {
        DataType InitValue { get; }
        DataType Value { get; set; }
        bool Changed { get; }
    }
        
    /// <summary>
    /// 表示可以被描述的对象
    /// </summary>
    public interface IDescription
    {
        string Description { get; set; }
    }

    /// <summary>
    /// 表示可以从DataRow加载数据的对象
    /// </summary>
    //public interface IDataRowReader
    //{
    //    bool LoadFromRow(System.Data.DataRow row);
    //}

    /// <summary>
    /// 表示有Load(T)和Save()方法的泛型对象
    /// </summary>
    //public interface IRW<IDType>
    //{
    //    EventResult Load(IDType id);
    //    EventResult Save();
    //}

    /// <summary>
    /// 表示需要记录用户名的对象
    /// </summary>
    public interface IUserName
    {
        string UserName { get; set; }
    }

    /// <summary>
    /// 表示需要密码验证的对象
    /// </summary>
    public interface IPassword
    {
        string Password { get; set; }
    }

    /// <summary>
    /// 表示有关键字的对象，可以通过关键字检索之。
    /// </summary>
    public interface IKey
    {
        string Key { get; set; }
    }
}
