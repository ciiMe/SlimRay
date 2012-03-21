using System;
using System.Collections.Generic;

using SR.Base.Interface;

using SR.Base.Abstract;

namespace SR.Data.DB.SORM
{
    /*
     * MyLinQ
     * 
     * 这里定义了用户层次的数据对象，
     * 
     * 用户层次的数据对象，封装了对数据库数据的引用，是对数据库的一个映射，可以直接是映射一张数据表，也可以是视图或者一个join语句
     * 
     * 该对象可以直接在usl中被继承使用，和相关helper配合可以直接加载数据库数据，
     * 
     * 这里只是基础的框架实现，用户继承时候只需要增加字段来管理映射即可。
     * 
     * helper可根据条件返回数组、数据表、数值等。
     * 
     * 终极目标：比如有UserData对象 SysUser，那么该对象支持如下的方法：
     * 
     * SysUser u = new SysUser();
     * 
     * 检索：
     * 
     * UserDataHelper.SelectValue(u.RealName,u.ID.Equal(1).AsString();
     * 
     * UserDataHelper.SelectValue(u.All,u.ID.Equal(1) ).AsDataTable();
     * 
     * 更新
     * 
     * UserDataHelper.Update(u.RealName.Set("tom") + u.Password.Set( "111111"),u.ID.Equal(1) + u.Valid.Not(false));
     * 
     * 
     * 涉及：运算符重载
     * 
     * 数据关系映射
     * 
     * 
     */


    /// <summary>
    /// 用户数据对象
    /// </summary>
    public interface IUserData:IID<int>,IIndex, IName,IDescription ,IValid
    {

    }

    public class UserData : A_ID_Index_Name_Valid_Description<int>, IUserData
    {
    }
}
