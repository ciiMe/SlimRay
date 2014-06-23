using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SR.UI.DesignTime.Data.SysDataManager;

namespace SR.UI.DataDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();

            string err;

            if (um.IsPasswordMatch(textBox1.Text, textBox2.Text, out err))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show(err, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
