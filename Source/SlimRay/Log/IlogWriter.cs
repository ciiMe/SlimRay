﻿
namespace SlimRay.Log
{
    public interface ILogWriter
    {
        /// <summary>
        /// write log to default log file.
        /// </summary>
        void Append(string log);

        /// <summary>
        /// write log for special domain
        /// </summary>
        void Append(int domainId, string log);

        void Error(string msg);
        void Warn(string msg);
        string Message(string msg);
    }
}
