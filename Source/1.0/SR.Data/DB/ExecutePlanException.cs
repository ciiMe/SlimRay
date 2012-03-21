using System;

using SR.Base.Interface;

using SR.Base.Abstract;

namespace SR.Data.DB
{
    public static class ExecutePlanException
    {
        public static Exception Parameter_Exists = new Exception("参数{0}已经存在。");
        public static Exception Parameter_NullName = new Exception("参数名不能为空。");
        public static Exception Parameter_UnvalidName = new Exception("参数{0}不是合法的名称。");
    }


}
