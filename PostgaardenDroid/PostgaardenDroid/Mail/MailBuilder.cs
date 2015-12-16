using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PostgaardenMail.Dummy;
//using System.Net;
//using System.Net.Mail;
using Postgaarden;
using Postgaarden.Model.Persons;
using PostgaardenMail;

namespace Postgaarden.Mail
{
    public class MailBuilder
    {
        //Created By Jens Kloster with help of Martin

        public MailBuilder()
        {

        }

        public Mailtemplate CreateMail(Booking booking)
        {
            var bookingString = "";
            bookingString += "<ul>";
            foreach (var e in booking.Room.Equipments)
            {
                bookingString += "<li>" + e.Name + "</li>";
            }
            bookingString += "</ul>";
            Mailtemplate mail = new Mailtemplate();
            mail.Receiver = booking.Customer.EmailAddress;
            mail.Sender = "Postgaarden@gmail.com";
            mail.Subject = "Faktura for betaling til hotel Postgaarden";
            mail.Body = "<h1>Hotel Postgaarden booking</h1>";
            mail.Body += @"<p> Tak for at have booked et rum ved Hotel Postgaarden <br /> 
            Denne mail er til for at bekræfte din ordre </p >";
            mail.Body += "<p>" + booking.Room.Name + @" <br />
            Din booking af rummet starter " + booking.StartTime + ", og slutter " + booking.EndTime + @" <br />
            Størrelsen på rummet du har bestilt er op til " + booking.Room.Size + " personer, og udstyr i rummet " + bookingString + @"
            Faktureringsinformation: <br />
            " + ((Customer)booking.Customer).Name + @"<br />
            " + ((Customer)booking.Customer).EmailAddress + @" <br /> 
            " + ((Customer)booking.Customer).Cvr + @" <br />
            " + ((Customer)booking.Customer).CompanyName +@" <br />    
            Total pris på booking: <br />
            " + booking.Price + @" <br /> </p>";
            mail.Signature = "<h2>Best Regards</h2>";
            mail.Signature += "<p>" + ((Employee)booking.Employee).Name + @" <br /> 
            Hotel Postgaarden<p>";
            mail.UserName = "postgaardentest@gmail.com";
            mail.Password = "posttest";

            return mail;
        }
    }
}
