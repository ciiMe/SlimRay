using HtmlAgilityPack;
using System;
using HtmlAnalyser.Log;

namespace HtmlAnalyser.HtmlAnalysis
{
    public class BaseTaskExecutor : ITaskExecutor, IHtmlDataHelper
    {
        public virtual void Execute(DataProcessTask task)
        {
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc;
            try
            {
                  doc = webClient.Load(task.Url);
            }
            catch (Exception ex)
            {
                LogWritor.Error(task.Url, "Open URL fail:" + ex.Message);
                return;
            }

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(task.XPathRoot);

            if (nodes == null || nodes.Count == 0)
            {
                LogWritor.Error(task.Url, task.XPathRoot, "Nodes not found.");
                return;
            }

            foreach (HtmlNode node in nodes)
            {
                ReadLine(node, ref task);
            }
        }

        /// <summary>
        /// get text of the first node in the xpath.
        /// </summary>
        /// <returns></returns>
        public string GetNodeInnerText(HtmlNode node, string xpath)
        {
            HtmlNode data = node.SelectSingleNode(xpath);
            return data == null ? "" : data.InnerText;
        }

        public virtual void ReadLine(HtmlNode node, ref DataProcessTask task)
        {
            for (int i = 0; i < task.DataLines.Count; i++)
            {
                ProcessTaskDataLine line = task.DataLines[i];
                line.InnerText = GetNodeInnerText(node, line.XPath);

                if (string.IsNullOrEmpty(line.InnerText))
                {
                    LogWritor.Warn(task.Url, task.XPathRoot, "Data not found in line:" + line.XPath);
                }

                task.DataLines[i] = line;
            }
        }
    }
}
