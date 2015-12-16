using Postgaarden.Crud.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Connection.Sqlite;

namespace Postgaarden.Model.Rooms
{
    /*
        Developed by Chris Wohlert
    */
    public class RoomHandler
    {
        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>
        /// The rooms.
        /// </value>
        public List<Room> Rooms { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomHandler"/> class.
        /// </summary>
        /// <param name="crud">The crud.</param>
        public RoomHandler(RoomCrud crud)
        {
            Rooms = crud.Read().ToList();
        }
        /// <summary>
        /// Filters rooms by equipment
        /// </summary>
        /// <param name="equipment">All the equipment required</param>
        /// <returns>Returns a new collection of rooms containing only the rooms with all the required equipment</returns>
        public IEnumerable<Room> Filter(IEnumerable<string> equipment)
        {
            return
            Rooms.Where(
                room => room.Equipments
                .Select(equip => equip.Name)
                .Intersect(equipment).Count() == equipment.Count())
                .ToList();
        }

        /// <summary>
        /// Filters room by size
        /// </summary>
        /// <param name="size">The size of the room</param>
        /// <param name="minimum">If true, all rooms of this size or bigger will match</param>
        /// <returns>Returns a new collection of rooms with the specified size</returns>
        public IEnumerable<Room> Filter(int size, bool minimum)
        {
            return Rooms.Where(room => minimum ? room.Size >= size : room.Size == size);
        }
    }
}
