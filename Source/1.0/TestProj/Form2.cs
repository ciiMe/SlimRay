using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestProj
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                return;
            }

            if (!ThreadDialog.CloseFlag)
            {
                return;
            }

            this.timer1.Enabled = false;

            this.DialogResult = DialogResult.OK;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
    }
}
