
namespace SlimRay.DB.Helpers
{
    public class MSSQLExecutorCreator : IExecutorCreator
    {
        private const string _name = "MSSQL Executor creator";
        private const string _description = "Create executor to execute MSSQL request.";
        private const string _key = "MSSQL";

        public IExecutor New()
        {
            return new MSSQLHelper();
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetKey()
        {
            return _key;
        }
    }
}
