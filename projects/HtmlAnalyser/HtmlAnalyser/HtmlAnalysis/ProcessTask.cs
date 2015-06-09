using System.Collections.Generic;

namespace HtmlAnalyser.HtmlAnalysis
{
    public class DataProcessTask
    {
        public string Url { get; set; }
        public string XPathRoot { get; set; }
        public List<ProcessTaskDataLine> DataLines { get; set; }

        public DataProcessTask()
        {
            Url = "";
            XPathRoot = "";
            DataLines = new List<ProcessTaskDataLine>();
        }
    }

    public class ProcessTaskDataLine
    {
        public string Name { get; set; }
        public string XPath { get; set; }
        public string InnerText { get; set; }
    }
}
