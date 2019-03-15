using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public void SendEmail(string email, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email);

            mail.From = new MailAddress("nguyenthequyen13@gmail.com");
            mail.Subject = subject;

            string Body = body;
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential
                 ("nguyenthequyen13@gmail.com", "THEQUYEN96");

            smtp.EnableSsl = true;
            //smtp.Send(mail);
        }
    }
}
