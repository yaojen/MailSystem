using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MailSystem
{
    class Program
    {
        static string From = Properties.Settings.Default.From;
        static bool IsBodyHtml = Properties.Settings.Default.IsBodyHtml;
        static string Name = Properties.Settings.Default.Name;
        static string Host = Properties.Settings.Default.Host;
        static string Password = Properties.Settings.Default.Password;
        static int Port = Properties.Settings.Default.Port;
        static bool EnableSsl = Properties.Settings.Default.EnableSsl;




        static void Main(string[] args)
        {
            SendMailByGmail();
            Console.ReadLine();

        }

        static void SendMailByGmail()
        {
            MailMessage mms = new MailMessage();

            //寄件人(寄件人Email,寄件人顯示的名稱,編碼方式)
            mms.From = new MailAddress(From, Name, System.Text.Encoding.UTF8);

            //標題
            mms.Subject = "郵件主題";

            //內容(來源可已是txt或資料庫)
            mms.Body = "郵件內容";

            //內容是否html
            mms.IsBodyHtml = IsBodyHtml;

            //內容編碼方式
            mms.BodyEncoding = System.Text.Encoding.UTF8;

            //優先權
            mms.Priority = MailPriority.Normal;

            //收件人
            mms.To.Add("xxxxxxxx@gmail.com");

            //密件副本
            mms.Bcc.Add("xxxx@gmail.com");

            //夾帶檔
            Attachment file = new Attachment("檔案路徑");
            mms.Attachments.Add(file);


            //計件
            SmtpClient MySmtp = new SmtpClient(Host, Port)
            {
                EnableSsl = EnableSsl,
                Credentials = new NetworkCredential(From, Password)
            };

            try
            {
                MySmtp.Send(mms);
                MySmtp.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
