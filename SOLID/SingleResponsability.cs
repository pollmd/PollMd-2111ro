using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class EmailService
    {
        public void Register(string email)
        {
            DataValidator dv = new DataValidator();

            if (dv.ValidateEmail(email))
            {
                SendMail(new MailMessage("info@poll.md", email)
                {
                    Subject = "Hello!",
                    Body = "un pic de spam"
                });  
            }
        }

        private void SendMail(MailMessage mail)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Send(mail);
        }
    }

    public class DataValidator
    {
        public bool ValidateEmail(string email)
        {
            return email.Contains('@');
        }
    }
}
