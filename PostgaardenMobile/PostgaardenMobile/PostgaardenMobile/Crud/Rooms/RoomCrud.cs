using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Model.Rooms;
using Postgaarden.Connection;

namespace Postgaarden.Crud.Rooms
{
    /*
        Developed by Chris Wohlert
    */
    public abstract class RoomCrud : Crud<Room, int>
    {
        public abstract Room Read(Booking booking);
    }
}
