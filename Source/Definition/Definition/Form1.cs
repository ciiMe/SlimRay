﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SlimRay.Definition.Data.SysDataManager;

namespace SlimRay.Definition
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

            if (!um.IsPasswordMatch(textBox1.Text, textBox2.Text, out err))
            {
                MessageBox.Show(err, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataKeeping.StaticItems.CurrentUser = um.Load(textBox1.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
