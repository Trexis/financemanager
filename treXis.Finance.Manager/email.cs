using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Trexis.Finance.Manager
{
    public class Email
    {
        private string smtpserver = "mail.meulenfoods.co.za";
        private int smtpport = 110;
        private string smtpusername = "accounts@meulenfoods.co.za";
        private string smtppassword = "Accounts556#";
        private Boolean smtpssl = true;
        private string emailfromaddress = "accounts@meulenfoods.co.za";
        private string emailfromfriendly = "MeulenFoods";
        private string emailreplyaddress = "louis@meulenfoods.co.za";
        private string errormessage = "";

        public Email()
        {
            Config config = new Config();
            this.smtpserver = config.GetSetting("smtp.server");
            this.smtpport = Convert.ToInt16(config.GetSetting("smtp.port"));
            this.smtpusername = config.GetSetting("smtp.username");
            this.smtppassword = config.GetSetting("smtp.password");
            this.smtpssl = Convert.ToBoolean(config.GetSetting("smtp.ssl"));
            this.emailfromaddress = config.GetSetting("email.from.address");
            this.emailfromfriendly = config.GetSetting("email.from.friendly");
            this.emailreplyaddress = config.GetSetting("email.reply.address");
        }

        public Boolean Send(String toEmail, String toFriendlyName, String subject, String HTML)
        {
            try
            {
                SmtpClient smtpclient = new SmtpClient();
                smtpclient.Host = this.smtpserver;
                smtpclient.Credentials = new System.Net.NetworkCredential(this.smtpusername, this.smtppassword);
                smtpclient.Port = this.smtpport;
                smtpclient.EnableSsl = this.smtpssl;


                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(toEmail, toFriendlyName));
                message.From = new MailAddress(this.emailfromaddress, this.emailfromfriendly);
                message.ReplyToList.Add(new MailAddress(this.emailreplyaddress, this.emailfromfriendly));
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Body = HTML;
                message.BodyEncoding = Encoding.UTF8;

                smtpclient.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                this.errormessage = ex.Message;
                return false;
            }
        }

        public String ErrorMessage
        {
            get { return this.errormessage; }
        }
    }
}
