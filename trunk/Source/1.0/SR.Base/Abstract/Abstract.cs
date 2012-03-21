
using SR.Base.Interface;

namespace SR.Base.Abstract
{
    public abstract class A_ID<IDType> : IID<IDType>
    {
        protected IDType _ID;

        public IDType ID
        {
            get { return _ID; }
        }
    }

    public abstract class A_Index : IIndex
    {
        protected int _Index;
        public int Index
        {
            get { return _Index; }
        }
    }

    public abstract class A_Index_Name : A_Index, IName
    {
        protected string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public abstract class A_ID_Name<IDType> : A_ID<IDType>, IName
    {
        protected string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public abstract class A_ID_Index<IDType> : A_ID<IDType>, IIndex
    {
        protected int _Index;

        public int Index
        {
            get { return _Index; }
        }
    }

    public abstract class A_ID_Index_Name<IDType> : A_ID_Index<IDType>, IName
    {
        protected string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public abstract class A_UserName : IUserName
    {
        protected string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
    }

    public abstract class A_Password : IPassword
    {
        protected string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
    }

    public abstract class A_ID_Index_Name_Valid_Description<idType> : A_ID_Index_Name<idType>, IValid, IDescription 
    {
        private bool _Valid;
        private string _Description;

        #region IValid 成员

        public bool Valid
        {
            get
            {
                return _Valid;
            }
            set
            {
                _Valid = value;
            }
        }

        #endregion

        #region IDescription 成员

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        #endregion
    }


}
