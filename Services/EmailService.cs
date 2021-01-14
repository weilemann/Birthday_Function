using System;
using System.Net;
using System.Net.Mail;

namespace BirthdayFunction.Services
{
    public class EmailService
    {
        readonly string _emailUsername;
        readonly string _emailPassword;

        public EmailService(string emailUsername, string emailPassword)
        {
            _emailUsername = emailUsername;
            _emailPassword = emailPassword;
        }

        public void SendEmail(string displayName, string to, string subject, string messageBody)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential()
                {
                    UserName = _emailUsername,
                    Password = _emailPassword,
                }
            };

            MailAddress fromEmail = new MailAddress(_emailUsername, displayName);
            MailAddress toEmail = new MailAddress(to);
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = subject,
                Body = messageBody,
            };

            message.To.Add(toEmail);

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
