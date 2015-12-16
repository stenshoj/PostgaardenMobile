using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.PostgaardenMail;
using System.Net;
using System.Net.Mail;

namespace Postgaarden.PostgaardenMail
{
    class MailBuilder
    {

        public MailBuilder(Mailtemplate template)
        {
            Mail mail = new Mail();
            mail.Receiver = "othermail@gmail.com";
            mail.Sender = "thismail@gmail.com";
            mail.Subject = "ConferenceRoom booking from hotel SUN";
            //Create styles for the header h1!?
            mail.Body = "<h1>This is the header for the email</h1>";
            mail.Body += "<p>This is the paragraph for the email</p>";
            //Create styles for the header h2!?
            mail.Signature = "<h2>Best Regards</h2>";
            mail.Signature += "<p>Jes James, Merch<p>";
            mail.UserName = template.UserName;
            mail.Password = template.Password;
        }
    }
}
