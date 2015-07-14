using SlimRay.DB;

namespace DBHelpers.MSSQL
{
    public class SqlCommandTranslator : IDBCommandTranslator
    {
        public string ToDBCommand(DBRequest request)
        {
            return request.Command;
        }
    }
}
