
namespace SlimRay.Log
{
    public interface IlogWriter
    {
        /// <summary>
        /// write log to default log file.
        /// </summary>
        void Append(string log);

        /// <summary>
        /// write log for special domain
        /// </summary>
        void Append(int domainId, string log);
    }
}
