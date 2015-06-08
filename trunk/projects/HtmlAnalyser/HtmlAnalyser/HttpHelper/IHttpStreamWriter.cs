using System.IO;

namespace HtmlAnalyser.HTTPHelper
{
    public interface IHttpStreamWriter
    {
        void Write(Stream stream, string data);
    }
}
