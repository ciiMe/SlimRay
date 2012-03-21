using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.Mail;

namespace TestProj
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }


        public void sendMain()
        {
            //邮件的发件人
            MailAddress from = new MailAddress("gaosheng@hotmail.com", "高升");

            MailMessage mail = new MailMessage();

            //设置邮件的标题
            mail.Subject = "";

            //设置邮件的发件人
            //Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用
            mail.From = from;

            //设置邮件的收件人
            string address = "";
            string displayName = "";
            /*  这里这样写是因为可能发给多个联系人，每个地址用 ; 号隔开
              一般从地址簿中直接选择联系人的时候格式都会是 ：用户名1 < mail1 >; 用户名2 < mail 2>; 
              因此就有了下面一段逻辑不太好的代码
              如果永远都只需要发给一个收件人那么就简单了 mail.To.Add("收件人mail");
            */
            string[] mailNames = ("txtMailTo.Text" + ";").Split(';');
            foreach (string name in mailNames)
            {
                if (name != string.Empty)
                {
                    if (name.IndexOf('<') > 0)
                    {
                        displayName = name.Substring(0, name.IndexOf('<'));
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    else
                    {
                        displayName = string.Empty;
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    mail.To.Add(new MailAddress(address, displayName));
                }
            }

            //设置邮件的抄送收件人
            //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好
            mail.CC.Add(new MailAddress("Manage@hotmail.com", "尊敬的领导"));

            //设置邮件的内容
            mail.Body = "txtBody.Text";
            //设置邮件的格式
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            //设置邮件的发送级别
            mail.Priority = MailPriority.Normal;

            //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中
            string fileName = "txtUpFile.PostedFile.FileName.Trim()";
            fileName = "D:/UpFile/" + fileName.Substring(fileName.LastIndexOf("/") + 1);
            // 将文件保存至服务器
            //txtUpFile.PostedFile.SaveAs(fileName); 
            mail.Attachments.Add(new Attachment(fileName));

            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

            SmtpClient client = new SmtpClient();
            //设置用于 SMTP 事务的主机的名称，填IP地址也可以了
            client.Host = "smtp.hotmail.com";
            //设置用于 SMTP 事务的端口，默认的是 25
            //client.Port = 25;
            client.UseDefaultCredentials = false;
            //这里才是真正的邮箱登陆名和密码，比如我的邮箱地址是 hbgx@hotmail， 我的用户名为 hbgx ，我的密码是 xgbh
            client.Credentials = new System.Net.NetworkCredential("hbgx", "xgbh");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //都定义完了，正式发送了，很是简单吧！
            client.Send(mail);
        }


        public bool SendMail(MailAddress Messagefrom, string MessageTo, string MessageSubject, string MessageBody)
        {
            MailMessage message = new MailMessage();
            message.From = Messagefrom;
            //收件人邮箱地址可以是多个以实现群发 
            message.To.Add(MessageTo);
            message.Subject = MessageSubject;
            message.Body = MessageBody;
            //是否为html格式 
            message.IsBodyHtml = true;
            //发送邮件的优先等级   
            message.Priority = MailPriority.High;


            SmtpClient sc = new SmtpClient();
            //指定发送邮件的服务器地址或IP 
            sc.Host = "smtp.163.com";
            //指定发送邮件端口 
            sc.Port = 25;
            //sc.UseDefaultCredentials = true; 
            //sc.EnableSsl = true; 
            //指定登录服务器的用户名和密码
            sc.Credentials = new System.Net.NetworkCredential("chaome545@163.com", "xaini1");

            try
            {
                //发送邮件 
                sc.Send(message);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (SendMail(new MailAddress("chaome545@163.com", "孙潮宗", Encoding.UTF8), "chaome545@163.com", "hello subject", "hello body.<br /><div>this is a div</div>"))
            {
                MessageBox.Show("success!");
            }
            else
            {
                MessageBox.Show("Failed!");
            }

        }
    }
}
