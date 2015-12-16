using Postgaarden.Model.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgaarden.Crud.Persons
{
    //Created by Jens Kloster
    public abstract class CustomerCrud: Crud <Customer, string>
    {
        /// <summary>
        /// Reads the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        public abstract Customer Read(Booking booking);
    }
}
