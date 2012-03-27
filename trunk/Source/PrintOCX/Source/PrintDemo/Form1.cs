using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SlimRayPrintOCX;

namespace PrintDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlimRayPrintClass sp = new SlimRayPrintClass();

            sp.ReportFileName = @"E:\Source\CardServer\Include\Vars.fr3";

            sp.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;Initial Catalog=CardServer;Data Source=10.130.0.24";
            sp.AddSQL("frdd", "select * from cardbinding where bindid like '%#%'");

            sp.AddVariant_String("PrintUser", "要卫鹏");
            sp.AddVariant_Int("UserAge", 20);
            sp.AddVariant_Boolean("isNormal", true);
            sp.AddVariant_DateTime("BirthDay", DateTime.Now.AddMonths(-1).Date);
            sp.AddVariant_Double("TotalMoney", 21548.12);

            sp.Preview();
        }
    }
}