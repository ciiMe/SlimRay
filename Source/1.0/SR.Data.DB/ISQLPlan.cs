

namespace SR.Data.DB
{
    public interface ISQLPlan : IExecutePlan, ISQLText, IParameters
    {
        /// <summary>
        /// 数据库链接信息，如果为null那么会使用默认的数据库链接。
        /// </summary>
        IConnectionInfo ConnectionInfo { get; set; }
        ExecuteCommandType CommandType { get; set; }
    }
}
