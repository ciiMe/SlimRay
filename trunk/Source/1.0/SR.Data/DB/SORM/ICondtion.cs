using System;
using System.Text;

namespace SR.Data.DB.SORM
{
    /* 
     * 这里定义条件对象，这些对象可以支持条件处理中的一般方法，
     * 
     * 这些方法有：
     * 
     * 等于、不等于、大于、小于、包含、不包含、like
     * 
     * 在数据请求的过程中，
     * 
     * Helper通过该对象记录的条件，来生成查询条件。
     * 
     * 此对象也是数据列的子集，数据列定义了数据和数据类型以及数据映射，而这里定义了支撑查询条件的方法。
     *
     */

    /// <summary>
    /// 表示可以承载条件的对象
    /// </summary>
    /// <typeparam name="valType">对象的类型</typeparam>
    public interface ICondtion<valType>
    {

    }
}
