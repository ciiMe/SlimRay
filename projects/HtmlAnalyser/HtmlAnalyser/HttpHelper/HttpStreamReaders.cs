using System.IO;
using System.Text;

namespace HtmlAnalyser.HTTPHelper
{
    public class StringReader : IHttpStreamReader
    {
        public string Read(Stream stream)
        {
            StreamReader sReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
            return sReader.ReadToEnd();
        }
    }

    public class StringWriter : IHttpStreamWriter
    {
        public void Write(Stream stream, string data)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(data);
        }
    }
}