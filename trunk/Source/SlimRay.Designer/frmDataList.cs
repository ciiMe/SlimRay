using System;
using System.Windows.Forms;
using SlimRay.UserData;
using SlimRay.App;

namespace SlimRay.Designer
{
    public partial class frmDataList : Form
    {
        public frmDataList()
        {
            InitializeComponent();

            loadAllData();
        }

        private void loadAllData()
        {
            var helper = SystemApps.GetUserDataHelper();

            var dataList = helper.Get();
            this.listBox1.DataSource = dataList;
            this.listBox1.DisplayMember = "Name";
        }

        private void showDataColumns(string dataName)
        {
            var helper = SystemApps.GetUserDataHelper();

            var data = helper.Get(dataName);
            this.dataGridView1.DataSource = data.Fields;

            var linkedData = helper.GetLinkedData(dataName);
            this.dataGridView2.DataSource = linkedData;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUserData data = this.listBox1.SelectedItem as IUserData;
            showDataColumns(data.Name);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataAdd frm = new frmDataAdd();

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string name = frm.DataName;
            string desc = frm.DataDescription;

            var helper = SystemApps.GetUserDataHelper();
            helper.AddData(name, desc);
            loadAllData();
        }

        private void renameSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                return;
            }

            IUserData data = this.listBox1.SelectedItem as IUserData;

            frmDataAdd frm = new frmDataAdd();

            frm.DataName = data.Name;
            frm.DataDescription = data.Description;

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string name = frm.DataName;
            string desc = frm.DataDescription;

            var helper = SystemApps.GetUserDataHelper();
            helper.SetNewName(data.Name, name);
            helper.SetDescription(data.Name, desc);
            loadAllData();
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                return;
            }

            IUserData data = this.listBox1.SelectedItem as IUserData;

            frmDataAdd frm = new frmDataAdd();

            frm.DataName = data.Name;
            frm.DataDescription = data.Description;

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var helper = SystemApps.GetUserDataHelper();
            helper.Remove(data.Name);

            loadAllData();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                return;
            }

            IUserData data = this.listBox1.SelectedItem as IUserData;

            frmFieldAdd frm = new frmFieldAdd();

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string name = frm.FieldName;
            string desc = frm.FieldDescription;
            UserFieldType t = frm.FieldType;

            var helper = SystemApps.GetUserDataHelper();
            helper.AddField(data.Name, name, t, desc);
            showDataColumns(data.Name);
        }
    }
}
