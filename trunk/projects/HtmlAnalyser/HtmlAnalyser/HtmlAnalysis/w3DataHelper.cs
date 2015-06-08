using HtmlAgilityPack;
using System;
using System.Windows.Forms;

namespace HtmlAnalyser.HtmlAnalysis
{
    /*analysis data in http://www.w3.org/,
     */
    public class w3DataHelper : BaseTaskExecutor
    {
        private TreeView _dataHolder;

        public w3DataHelper(TreeView dataHolder)
        {
            _dataHolder = dataHolder;
        }

        public override void Execute(DataProcessTask task)
        {
            _dataHolder.Nodes.Clear();
            task = createTask();
            base.Execute(task);
        }

        public override void ReadLine(HtmlNode node, ref DataProcessTask task)
        {
            base.ReadLine(node, ref task);
            TreeNode tnode = new TreeNode(task.DataLines[1].InnerText + ":" + task.DataLines[0].InnerText);
            tnode.ToolTipText = task.DataLines[2].InnerText;

            _dataHolder.Nodes.Add(tnode);
        }

        private DataProcessTask createTask()
        {
            /*
            url : http://www.w3.org/
            root: /html[1]/body[1]/div[1]/div[2]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div
            title: div[1]/h3[1]/span[1]
            date: div[1]/p[1]/span[1]
            detail: div[2]/p[1]
             */

            DataProcessTask task = new DataProcessTask();

            task.Url = "http://www.w3.org/";
            task.XPathRoot = "/html[1]/body[1]/div[1]/div[2]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div";

            task.DataLines.Add(new ProcessTaskDataLine { Name = "title", XPath = "div[1]/h3[1]/span[1]" });
            task.DataLines.Add(new ProcessTaskDataLine { Name = "date", XPath = "div[1]/p[1]/span[1]" });
            task.DataLines.Add(new ProcessTaskDataLine { Name = "detail", XPath = "div[2]/p[1]" });

            return task;
        }
    }
}
