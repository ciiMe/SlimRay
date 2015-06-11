using SlimRay.App;
using SlimRay.DB;
using System.Configuration;
using System.Data;

namespace HtmlAnalyser.DB
{
    internal class DBHelper
    {
        private string _dbHelperKey;
        private IExecutor _dbHelper;

        private DBAddress _dbAddress;

        public DBHelper()
        {
            _dbHelperKey = ConfigurationManager.AppSettings["DBHelperKey"];
            //todo: how's going while _dbHelper is null?
            _dbHelper = AppGate.Instance.Get(_dbHelperKey) as IExecutor;
            _dbAddress = new DBAddress()
            {
                Key = ConfigurationManager.AppSettings["DBType"],
                HostAddress = ConfigurationManager.AppSettings["DBAddress"]
            };
        }

        private DBRequest createRequest(string command)
        {
            return new DBRequest(_dbAddress)
            {
                Command = command
            };
        }

        public DataTable GetAsTable(DBRequest request)
        {
            return _dbHelper.GetDataTable(request);
        }

        public DataTable GetAsTable(string command)
        {
            return _dbHelper.GetDataTable(createRequest(command));
        }

        public void Execute(string command)
        {
            _dbHelper.Execute(createRequest(command));
        }

        public void Execute(DBRequest request)
        {
            _dbHelper.Execute(request);
        }
    }
}
