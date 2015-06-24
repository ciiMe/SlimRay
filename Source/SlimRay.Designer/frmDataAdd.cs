using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlimRay.Designer
{
    public partial class frmDataAdd : Form
    {
        /// <summary>
        /// the name of data user typed in the dialog.
        /// </summary>
        public string DataName
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }


        public string DataDescription
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public frmDataAdd()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text.Trim();
            this.textBox2.Text = this.textBox2.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }
    }
}
