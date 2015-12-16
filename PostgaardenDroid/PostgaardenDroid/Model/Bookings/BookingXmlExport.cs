using Postgaarden.Model.Equipments;
using Postgaarden.Model.Persons;
using Postgaarden.Model.Rooms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Bookings
{
    /*
        Developed by Christoffer Stenshøj
    */
    public class BookingXmlExport
    {
        /// <summary>
        /// Exports (serializes) the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <param name="writer">The writer.</param>
        public static void Export(Booking booking, TextWriter writer)
        {
            Type[] types = { typeof(Person), typeof(Customer), typeof(Employee), typeof(Room), typeof(ConferenceRoom), typeof(Equipment) };
            XmlSerializer seri = new XmlSerializer(typeof(Booking), types);
            seri.Serialize(writer, booking);
        }                 
    }
}
