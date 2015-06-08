using System;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlAnalyser.HtmlAnalysis;

namespace HtmlAnalyser
{
    public partial class frmDemo : Form
    {
        public frmDemo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HTTPHelper.HttpHelper helper = new HTTPHelper.HttpHelper();
            this.richTextBox1.Text = helper.Request(this.textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xpath = textBox2.Text;

            HtmlWeb webClient = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = webClient.Load(textBox1.Text);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(xpath);

            this.treeView1.Nodes.Clear();

            foreach (HtmlNode node in nodes)
            {
                TreeNode tnode = new TreeNode(node.InnerText);

                addNodeToNode(node, tnode);
                this.treeView1.Nodes.Add(tnode);
            }

            doc = null;
            nodes = null;
            webClient = null;
        }

        private void addNodeToNode(HtmlNode hnode, TreeNode tnode)
        {
            foreach (HtmlNode node in hnode.ChildNodes)
            {
                TreeNode child = new TreeNode(node.Name);
                child.ToolTipText = node.InnerText;
                tnode.Nodes.Add(child);
                addNodeToNode(node, child);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlWeb webClient = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = webClient.Load(textBox1.Text);

            HtmlNode root = doc.DocumentNode;
            this.treeView1.Nodes.Clear();

            foreach (HtmlNode node in root.ChildNodes)
            {
                TreeNode tnode = new TreeNode(node.Name);
                tnode.ToolTipText = node.InnerText;

                addNodeToNode(node, tnode);
                this.treeView1.Nodes.Add(tnode);
            }
        }

        /// <summary>
        /// get text of the first node in the xpath.
        /// </summary>
        /// <returns></returns>
        private string GetNodeInnerText(HtmlNode node, string xpath)
        {
            HtmlNode data = node.SelectSingleNode(xpath);
            return data == null ? "" : data.InnerText;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            w3DataHelper w3helper = new w3DataHelper(this.treeView1);
            w3helper.Execute(null);
        }
    }
}
