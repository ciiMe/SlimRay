using System.Collections.Generic;

namespace SlimRay.DB
{
    public class ExecutorFactory
    {
        private static ExecutorFactory _instance;
        private static bool _isInitialized;
        private Dictionary<string, IExecutorCreator> _creators;

        public static ExecutorFactory Instance
        {
            get
            {
                if (!_isInitialized)
                {
                    _instance = new ExecutorFactory();
                    _isInitialized = true;
                }

                return _instance;
            }
        }

        private ExecutorFactory()
        {
            _creators = new Dictionary<string, IExecutorCreator>();

            RegisterDefaultDBExecutor();
        }

        private void RegisterDefaultDBExecutor()
        {
            Helpers.MSSQLExecutorCreator mse = new Helpers.MSSQLExecutorCreator();
            Register(mse.GetKey(), mse);
        }

        private string formatKey(string key)
        {
            return key.ToLower().Trim();
        }

        public void Register(string key, IExecutorCreator ec)
        {
            key = formatKey(key);

            //todo: throw null,not exist exception
            _creators.Add(key, ec);
        }

        public void Unregister(string key)
        {
            key = formatKey(key);
            _creators.Remove(key);
        }

        public IExecutor New(string key)
        {
            key = formatKey(key);

            //todo:throw not exist exception.
            IExecutorCreator ec = _creators[key];

            return ec.New();
        }
    }
}
