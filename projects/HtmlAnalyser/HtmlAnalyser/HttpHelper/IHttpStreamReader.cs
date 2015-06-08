using System.IO;

namespace HtmlAnalyser.HTTPHelper
{
    public interface IHttpStreamReader
    {
        string Read(Stream stream);
    }
}
