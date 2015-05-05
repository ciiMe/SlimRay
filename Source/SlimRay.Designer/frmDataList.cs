using System;
using System.Windows.Forms;
using SlimRay.UserData;

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
            var loader = new UserDataLoader();


            var dataList = loader.Get();
            this.listBox1.DataSource = dataList;
            this.listBox1.DisplayMember = "Name";
        }

        private void showDataColumns(string dataName)
        {
            var loader = new UserDataLoader();

            var data = loader.Get(dataName);
            this.dataGridView1.DataSource = data.Fields;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserData.IUserData data = this.listBox1.SelectedItem as UserData.IUserData;
            showDataColumns(data.Name);
        }
    }
}
