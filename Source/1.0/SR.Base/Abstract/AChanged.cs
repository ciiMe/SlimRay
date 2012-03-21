using System;

using SR.Base.Interface;

namespace SR.Base.Abstract
{
    /// <summary>
    /// 记录了初始值和当前值的对象，并且标记是否被改变。
    /// </summary>
    /// <typeparam name="valType"></typeparam>
    /// <typeparam name="idType"></typeparam>
   public abstract  class AChanged<valType,idType>:A_ID_Index_Name_Valid_Description<idType>, IChanged<valType> where valType :IEquatable<valType>
    {
       private valType _InitValue;
       private valType _Value;

       private bool _Changed;

       public AChanged(valType val)
       {
           _InitValue = val;
           _Value = val;

           _Changed = false;
       }

        #region IChanged<valType> 成员

        public valType InitValue
        {
            get { return _InitValue; }
        }

        public valType Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;

                _Changed = _Value.Equals(_InitValue);
            }
        }

        public bool Changed
        {
            get { return _Changed; }
        }

        #endregion
    }
}
