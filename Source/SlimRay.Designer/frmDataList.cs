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

            var dataList = helper.GetData();
            this.listBox1.DataSource = dataList;
            this.listBox1.DisplayMember = "Name";
        }

        private void showDataColumns(string dataName)
        {
            var helper = SystemApps.GetUserDataHelper();

            var data = helper.GetData(dataName);
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

            data.Name = frm.DataName;
            data.Description = frm.DataDescription;


            var helper = SystemApps.GetUserDataHelper();
            helper.UpdateData(data.Name, data);

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
            helper.RemoveData(data.Name);

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

            UserFieldEntiry field = new UserFieldEntiry(frm.FieldName, frm.FieldDescription, frm.FieldType);

            var helper = SystemApps.GetUserDataHelper();
            helper.AddField(data.Name, field);

            showDataColumns(data.Name);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                return;
            }

            frmFieldAdd frm = new frmFieldAdd();
            IUserField field = this.dataGridView1.CurrentRow.DataBoundItem as IUserField;

            frm.FieldName = field.Name;
            frm.FieldDescription = field.Description;
            frm.FieldType = field.Type;

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            field.Name = frm.FieldName;
            field.Description = frm.FieldDescription;
            field.Type = frm.FieldType;

            var helper = SystemApps.GetUserDataHelper();

            helper.UpdateField(field.Data.Name, field.Name, field);

            showDataColumns(field.Data.Name);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                return;
            }

            IUserData data = this.listBox1.SelectedItem as IUserData;
            IUserField field = this.dataGridView1.CurrentRow.DataBoundItem as IUserField;

            frmFieldAdd frm = new frmFieldAdd();

            frm.FieldName = field.Name;
            frm.FieldDescription = field.Description;
            frm.FieldType = field.Type;

            frm.IsReadOnly = true;

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var helper = SystemApps.GetUserDataHelper();
            helper.RemoveField(data.Name, field.Name);
            showDataColumns(data.Name);
        }
    }
}
