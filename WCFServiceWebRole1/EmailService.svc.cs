using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    /// <summary>
    /// A very simple email service that could be used to send notification emails to people for multiple purposes.
    /// It uses the email "email.service.project@gmail.com"
    /// </summary>
    public class EmailService : IEmailService
    {
        private const string SmtpClient = "smtp.gmail.com";
        private const int smtpPort = 587;
        private const string EmailFrom = "email.service.project@gmail.com";
        private const string emailPw = "Email321";

        private void SendEmail(MailMessage mailToSend)
        {
            using (SmtpClient emailClient = new SmtpClient(SmtpClient, smtpPort))
            {
                emailClient.EnableSsl = true;
                emailClient.Timeout = 10000;
                emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = new NetworkCredential(EmailFrom, emailPw);

                emailClient.Send(mailToSend);
            }
        }
        
        /// <summary>
        /// Use this method to send the email, it creates the email from the parameters and then
        /// attempts to send it. The method returns true if the email was successfully sent.
        /// </summary>
        /// <param name="emailTo">The email address to send to.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The message body of the email.</param>
        /// <returns></returns>
        public bool CreateEmailAndSend(string emailTo, string subject, string body)
        {
            MailMessage email = new MailMessage(new MailAddress(EmailFrom), new MailAddress(emailTo))
            {
                Body = body,
                Subject = subject
            };
            try
            {
                SendEmail(email);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong, the e-mail was not sent.");
            }
        }
    }
}
