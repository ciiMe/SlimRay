using System;

namespace SlimRay.Log
{
    public class LogWritter : ILogWriter
    {
        private static ILogWriter _instance = new LogWritter();

        public static ILogWriter Instance
        {
            get { return LogWritter._instance; }
        }

        public void Append(string log)
        {

        }

        public void Append(int domainId, string log)
        {

        }

        public void Error(string msg)
        {
            throw new NotImplementedException();
        }

        public void Warn(string msg)
        {
            throw new NotImplementedException();
        }

        public string Message(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
