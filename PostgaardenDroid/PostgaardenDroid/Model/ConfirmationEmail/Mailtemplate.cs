using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Postgaarden.PostgaardenMail
{
    class Mailtemplate
    {

        public string UserName { get; set; } = "testingmail@gmail.com";
        public string Password { get; set; } = "MailForTesting123";
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Signature { get; set; }

    }
}
    

