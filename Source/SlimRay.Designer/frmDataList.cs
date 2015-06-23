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
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserData.IUserData data = this.listBox1.SelectedItem as UserData.IUserData;
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

            var helper = SystemApps.GetUserDataHelper();

            UserDataEntity data = new UserDataEntity(name);

            helper.AddUserData(data);
        }
    }
}
