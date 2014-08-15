/*
 * chaome，
 * all connection strings is supported by http://connectionstrings.com
 * 
 */

namespace SlimRay.Data.DB
{
    public interface IConnectionInfo 
    {
        ValidDBConnectionType ConnectionType { get; }

        string Password { get; set; }

        string ConnectionString { get; }
    }

    public abstract class ADBConnectionInfo : IConnectionInfo
    {
        protected string _Password;
        protected ValidDBConnectionType _ConnectionType;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public ValidDBConnectionType ConnectionType
        {
            get { return _ConnectionType; }
        }

        public ADBConnectionInfo()
        {
            _Password = "";
        }

        public abstract string ConnectionString { get; }
    }

    public abstract class AUserPasswordConnectionInfo : ADBConnectionInfo
    {
        protected string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public AUserPasswordConnectionInfo()
        {
            _UserName = "";
        }
    }

    public abstract class AServerDBConnection : AUserPasswordConnectionInfo
    {
        protected int _Port;

        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        protected string _HostAddress;

        public string HostAddress
        {
            get { return _HostAddress; }
            set { _HostAddress = value; }
        }

        public AServerDBConnection()
        {
            _Port = 0;
            _HostAddress = "";
        }
    }


    /// <summary>
    /// 代表指向MS SQL Server的数据库连接字符串
    /// </summary>
    public class MSSQL2000_ConnectionInfo : AServerDBConnection
    {
        private string _Catalog;

        public string Catalog
        {
            get { return _Catalog; }
            set { _Catalog = value; }
        }

        public MSSQL2000_ConnectionInfo()
        {
            _ConnectionType = ValidDBConnectionType.MSSQLServer2000;

            _Port = 1433;
        }

        public override string ConnectionString
        {
            get
            {
                return string.Format("Data Source={0},{4};Initial Catalog={1};User ID={2};password={3}",
                    _HostAddress, _Catalog, _UserName, _Password, _Port);
            }
        }
    }

    public abstract class AFileDBConnectionInfo : ADBConnectionInfo
    {
        protected string _FileName;

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public AFileDBConnectionInfo()
        {
            _FileName = "";
        }
    }

    /// <summary>
    /// 表示连接Access数据库的连接信息
    /// </summary>
    public class Access_ConnectionInfo : AFileDBConnectionInfo
    {
        public Access_ConnectionInfo()
        {
            _ConnectionType = ValidDBConnectionType.Access;
        }

        public override string ConnectionString
        {
            get
            {
                return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1}",
                    _FileName, _Password);
            }
        }
    }

    /// <summary>
    /// 表示连接到Oracle的数据库连接信息
    /// </summary>
    public class Oracle_ConnectionInfo : AUserPasswordConnectionInfo
    {
        private string _DataSource;

        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        public Oracle_ConnectionInfo()
        {
            _ConnectionType = ValidDBConnectionType.Oracle;
            _DataSource = "";
        }

        public override string ConnectionString
        {
            get
            {
                return string.Format("Data Source={0};User Id={1};Password={2};",
                    _DataSource,
                    _UserName,
                    _Password);
            }
        }
    }

    public class MySQL_ConnectionInfo : AServerDBConnection
    {
        private string _DataBase;

        public string DataBase
        {
            get { return _DataBase; }
            set { _DataBase = value; }
        }

        public MySQL_ConnectionInfo()
        {
            _ConnectionType = ValidDBConnectionType.MySQL;

            _Port = 3306;
        }

        public override string ConnectionString
        {
            get
            {
                return string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",
                    _HostAddress,
                    _Port,
                    _DataBase,
                    _UserName,
                    _Password
                    );
            }
        }
    }

    /// <summary>
    /// 表示连接到Excel的数据库连接
    /// </summary>
    public class Excel_ConnectionInfo : AFileDBConnectionInfo
    {
        public Excel_ConnectionInfo()
        {
            _ConnectionType = ValidDBConnectionType.Excel;
        }

        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + @FileName + ";Extended Properties=Excel 8.0;
        public override string ConnectionString
        {
            get
            {
                return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= {0};Extended Properties=Excel 8.0", _FileName);
            }
        }
    }
}
