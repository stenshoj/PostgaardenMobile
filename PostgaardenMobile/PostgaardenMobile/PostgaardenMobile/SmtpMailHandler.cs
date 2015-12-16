using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PostgaardenMail
{
    /*
        Developed by Martin Hansen
    */
    public class SmtpMailHandler
    {
        public SmtpMailHandler(Mailtemplate mail, string mailServer)
        {
            Mail = mail;
            MailServer = mailServer;
        }

        /// <summary>
        /// Sends an email using Google's SMTP server
        /// </summary>
        async public Task SendMailAsync()
        {
            // Establish server connection
            var client = new SmtpClient
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = MailServer,
                Credentials = new NetworkCredential(Mail.UserName, Mail.Password)
            };

            // Construct MailMessage
            var message = new MailMessage(Mail.Sender, Mail.Receiver)
            {
                Subject = Mail.Subject,
                Body = Mail.Body + "\n\n" + Mail.Signature
            };

            message.IsBodyHtml = true;

            await client.SendMailAsync(message);

            // Release the resources used by the MailMessage
            message.Dispose();
        }

        public Mailtemplate Mail { get; set; }
        public string MailServer { get; set; }
    }
}
