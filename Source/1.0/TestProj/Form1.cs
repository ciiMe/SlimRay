using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

// for db config
using SR.Data.DB;
using SR.Data.DB.DBFacory;

//for common use of sql helper
using SR.Data.DB.Helper;

namespace TestProj
{
    public partial class Form1 : Form
    {
        Form2 mskForm = new Form2();
        FormBorderStyle _Bs;

        public Form1()
        {
            InitializeComponent();
        }

        private void maskFormDisp()
        {
            //盖住主窗体,除标题栏及周围边框  


            mskForm.Location = new Point(this.Location.X , this.Location.Y );
            mskForm.Size = new Size(this.Width , this.ClientRectangle.Height );

            //显示等待窗体  
            mskForm.ShowDialog();
        }  

        private void button1_Click(object sender, EventArgs e)
        { 
            //static conn config
           // _Bs = this.FormBorderStyle;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            ////获得当前窗体的大小
            //Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            ////创建一个以当前窗体为模板的图象
            //Graphics g1 = this.CreateGraphics();
            ////创建以窗体大小为标准的位图  
            //Bitmap MyBMP = new Bitmap(rect.Width , rect.Height , g1);

            //this.DrawToBitmap(MyBMP,rect );

            //mskForm.pictureBox2.Image = MyBMP;

            //this.Visible = false;

            //Thread ThreadmaskForm = new Thread(maskFormDisp);
            //ThreadmaskForm.Start();

            _DoSQL();
            //在最后关掉,那个等待窗体  

           // mskForm.DialogResult = DialogResult.OK;
           // mskForm.Invalidate();

           //// this.FormBorderStyle = _Bs;
           // this.Visible = true;
        }

        private void _DoSQL()
        { 
            MSSQL2000_ConnectionInfo ci = new MSSQL2000_ConnectionInfo();

            ci.HostAddress = "211.211.211.7";
            ci.Catalog = "master";
            ci.UserName = "sa";
            ci.Password = "123";


            new SR.Data.DB.DBFacory.MSSQL2000.DBFactoryCreator_MSSQL2000().RegCreator();
            DBFacoryPool.Instance.AddConnectionInfo(ci);

            //conn in plan
            SQLTextPlan plan = new SQLTextPlan();
            plan.ConnectionInfo = ci;
            plan.SQLText.Append("select * from Budget_RQ..s_Power ");


            DBHelper helper = new DBHelper();

            this.dataGridView1.DataSource = helper.GetDataTable(plan);        
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            mskForm.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MySQL_ConnectionInfo ci = new MySQL_ConnectionInfo();

            //ci.HostAddress = "localhost";
            //ci.DataBase = "testdb";
            //ci.UserName = "root";
            //ci.Password = "xaini1";

            //SQLTextPlan plan = new SQLTextPlan();
            //plan.SQLText.Append("select * from d_Studnt;");

            //SR.Data.DB.MySQLExtend.Reg.doReg();
            //DBFacoryPool.Instance.AddConnectionInfo(ci);


            //DBHelper helper = new DBHelper();

            //this.dataGridView2.DataSource = helper.GetDataTable(plan);        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
            button1.PerformClick();
        }
    }
}
