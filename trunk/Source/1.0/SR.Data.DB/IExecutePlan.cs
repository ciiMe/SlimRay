/*
 * 数据Plan，可以封装对任何数据载体的执行请求，这些请求包括读取和写入
 * 
 * 读取和写入：可以从数据载体直接读取/写入，也可以由数据载体提供的方法读取/写入，比如存储过程等。
 * 
 * 
 * 
 */

namespace SR.Data.DB
{
    /// <summary>
    /// 表示数据请求和执行计划。
    /// This interface is not using right now,
    /// we only support SQLPlan in this version.
    /// we may do updateing works in feature version to support other plans.
    /// </summary>
    public interface IExecutePlan : IParameterCollection
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        int CommandTimeOut { get; set; }

        string CommandText { get; set; }
    }
}
