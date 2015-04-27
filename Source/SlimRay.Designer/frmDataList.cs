using System;
using System.Windows.Forms;

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
            var dataList = DataAccess.Store.Instance.Load();
            this.listBox1.DataSource = dataList;
            this.listBox1.DisplayMember = "Name";
        }

        private void showDataColumns(string dataName)
        {
            var data = DataAccess.Store.Instance.Load(dataName);
            this.dataGridView1.DataSource = data.Fields;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserData.IData data = this.listBox1.SelectedItem as UserData.IData;
            showDataColumns(data.Name);
        }
    }
}
