using System;
using System.Collections.Generic;
using System.Text;

using SR.Base.Types;

using SR.Data.DB.DBConst;
using SR.Data.DB.DBFacory;

namespace SR.Data.DB
{

    /// <summary>
    /// 表示普通sql文本的执行计划
    /// </summary>
    public class SQLTextPlan : ISQLPlan
    {
        private StringBuilder _SQLText;

        private ExecuteCommandType _CommandType;
        private List<KeyValuePair<string, object>> _Parameters;
        private bool _NullConvert;

        private int _CommandTimeOut;

        private bool _CreateTransaction;

        private IConnectionInfo _ConnectionInfo;

        public StringBuilder SQLText
        {
            get { return _SQLText; }
            set { _SQLText = value; }
        }

        public ExecuteCommandType CommandType
        {
            get { return _CommandType; }
            set { _CommandType = value; }
        }

        public List<KeyValuePair<string, object>> Parameters
        {
            get { return _Parameters; }
        }

        /// <summary>
        /// True：对传入的参数执行默认转换（-1，空字符串，按照规则被赋值为 null）
        /// </summary>
        public bool NullConvert
        {
            get { return _NullConvert; }
            set { _NullConvert = value; }
        }

        /// <summary>
        /// 本次执行的等待时间
        /// </summary>
        public int CommandTimeOut
        {
            get { return _CommandTimeOut; }
            set { _CommandTimeOut = value; }
        }

        /// <summary>
        /// 将语句包含在事务中执行
        /// </summary>
        public bool CreateTransaction
        {
            get { return _CreateTransaction; }
            set { _CreateTransaction = value; }
        }

        /// <summary>
        /// 本次数据库操作特定的数据库指向，可以为每一次数据库操作指定特定的数据库目标。
        /// </summary>
        public IConnectionInfo ConnectionInfo
        {
            get { return _ConnectionInfo; }
            set { _ConnectionInfo = value; }
        }

        private bool _CheckParameterNameForAdd(string name)
        {
            if (name.Trim() == "")
            {
                throw ExecutePlanException.Parameter_NullName;
            }

            if (ParameterNameExists(name))
            {
                throw ExecutePlanException.Parameter_Exists;
            }

            if (!IsCorrectName(name))
            {
                throw ExecutePlanException.Parameter_UnvalidName;
            }

            return true;
        }

        public bool _AddParameter(string name, object val)
        {
            if (!_CheckParameterNameForAdd(name)) return false;

            _Parameters.Add(new KeyValuePair<string, object>(name, val));
            return true;
        }

        public bool AddParameter(string name, int val)
        {
            if (_NullConvert && val == ConstValue.NULLINT)
            {
                return _AddParameter(name, DBNull.Value);
            }

            return _AddParameter(name, val);
        }
        public bool AddParameter(string name, string val)
        {
            if (_NullConvert && val == ConstValue.NULLSTRING)
            {
                return _AddParameter(name, DBNull.Value);
            }

            return _AddParameter(name, val);
        }
        public bool AddParameter(string name, double val)
        {
            if (_NullConvert && val == ConstValue.NULLDOUBLE)
            {
                return _AddParameter(name, DBNull.Value);
            }

            return _AddParameter(name, val);
        }
        public bool AddParameter(string name, DateTime val)
        {
            if (_NullConvert && val == ConstValue.NULLDATETIME)
            {
                return _AddParameter(name, DBNull.Value);
            }

            return _AddParameter(name, val);
        }
        public bool AddParameter(string name, bool val)
        {
            if (_NullConvert && val == ConstValue.NULLBOOL)
            {
                return _AddParameter(name, DBNull.Value);
            }

            return _AddParameter(name, val);
        }

        /// <summary>
        /// 判定该parName的存在，不区分大小写，自动Trim。
        /// </summary>
        /// <param name="parName"></param>
        /// <returns></returns>
        public bool ParameterNameExists(string parName)
        {
            string ts = parName.Trim().ToUpper();

            foreach (KeyValuePair<string, object> i in _Parameters)
            {
                if (ts == i.Key.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判定该parName的可用性，将检查parName中的特殊字符。
        /// </summary>
        /// <param name="parName"></param>
        /// <returns></returns>
        public bool IsCorrectName(string parName)
        {
            return true;
        }

        public SQLTextPlan()
        {
            _SQLText = new StringBuilder();

            _CommandType = ExecuteCommandType.CommandText;
            _Parameters = new List<KeyValuePair<string, object>>();
            _NullConvert = false;

            _CommandTimeOut = DBHelperConst.DBCommand.CommandTimeOut;

            _CreateTransaction = false;
        }

        /// <summary>
        /// 返回ExecutePlan中的SQL文本的内容
        /// </summary>
        /// <returns></returns>
        public string GetSQLText()
        {
            return _SQLText.ToString();
        }

        /// <summary>
        /// 将Parameter生成数组的形式
        /// </summary>
        /// <returns></returns>
        public System.Data.Common.DbParameter[] GetParameters()
        {
            List<System.Data.Common.DbParameter> re = new List<System.Data.Common.DbParameter>();

            foreach (KeyValuePair<string, object> i in _Parameters)
            {
                re.Add(DBFacoryPool.Instance.NewDBParameter(_ConnectionInfo, i.Key, i.Value));
            }

            return re.ToArray();
        }
    }
}
