using System.Data;
using SlimRay.App;
using SlimRay.DB;
using SlimRay.Utils;
using System.Text;

namespace SlimRay.Data.TableData
{
    public class MSSQLAccessApp : IDataAccessApp
    {
        public DBRequest TranslateRequest(DataRequest request)
        {
            //todo: is there any different between these address???
            DBRequest dbRq = new DBRequest(request.Address)
            {
                Command = buildCommand(request)
            };

            fillDBRequestParameters(request, ref dbRq);

            return dbRq;
        }

        private void fillDBRequestParameters(DataRequest request, ref DBRequest result)
        {
            int i = 0;
            foreach (var pars in request.Parameters)
            {
                foreach (var p in pars.Values)
                {
                    i++;
                    result.AddParameter("p" + i.ToString(), p);
                }
            }
        }

        private IExecutor getInstalledExecutor(DataRequest request)
        {
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

            if (ex != null)
            {
                return ex;
            }

            throw new NoAppRegisterExceptioin(getNoExecutorErrMessage(request));
        }

        private string getNoExecutorErrMessage(DataRequest request)
        {
            return string.Format("App:{0} is not installed.", request.Address.DataKey);
        }

        private string buildCommand(DataRequest request)
        {
            string sql = "";

            switch (request.Target)
            {
                case DataTarget.Data:
                    {
                        sql = buildDataActionSQL(request);
                    } break;
                case DataTarget.Field:
                    {
                        sql = buildFieldActionSQL(request);
                    } break;
                case DataTarget.FieldValue:
                    {
                        sql = buildValueActionSQL(request);
                    } break;
            }

            return sql;
        }

        private string buildDataActionSQL(DataRequest request)
        {
            throw new System.NotImplementedException();
        }

        private string buildFieldActionSQL(DataRequest request)
        {
            throw new System.NotImplementedException();
        }

        private string buildValueActionSQL(DataRequest request)
        {
            string sql = "";

            switch (request.Action)
            {
                case DataAction.Get:
                    {
                        sql = string.Format("select {0} from {1} where {2}", getSQLFields(request), getSQLDataName(request), getSQLParameters(request));
                    } break;
                case DataAction.Add:
                    { } break;
                case DataAction.Remove:
                    { } break;
                case DataAction.Update:
                    { } break;
            }

            return sql;
        }

        private string getSQLFields(DataRequest request)
        {
            return StringHelper.ArrayToString(request.RequestFields);
        }

        private string getSQLDataName(DataRequest request)
        {
            return request.DataName;
        }

        private string getSQLParameters(DataRequest request)
        {
            StringBuilder b = new StringBuilder();

            int i = 0;
            foreach (var item in request.Parameters)
            {
                if (item.Values.Length <= 0)
                {
                    continue;
                }
                else if (item.Values.Length == 1)
                {
                    b.AppendFormat("{0} = {1}{2}", item.FieldName, "p", i);
                }
                else
                {
                    b.AppendFormat("{0} in  ", item.FieldName);
                    b.Append("(");
                    string pars = "";
                    foreach (string p in item.Values)
                    {
                        i++;
                        if (pars == "")
                        {
                            pars = "p" + i.ToString();
                        }
                        else
                        {
                            pars = pars + ",p" + i.ToString();
                        }
                    }
                    b.Append(pars);
                    b.Append(")");
                }
            }

            return b.ToString();
        }

        public DataTable GetTable(DataRequest request)
        {
            DBRequest r = TranslateRequest(request);
            IExecutor ex = getInstalledExecutor(request);

            return ex.GetDataTable(r);
        }

        public string GetValue(DataRequest request)
        {
            DBRequest r = TranslateRequest(request);
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

            return ex.GetResult(r).ToString();
        }

        public bool Execute(DataRequest request)
        {
            DBRequest r = TranslateRequest(request);
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

            return ex.Execute(r) > 0;
        }
    }
}
