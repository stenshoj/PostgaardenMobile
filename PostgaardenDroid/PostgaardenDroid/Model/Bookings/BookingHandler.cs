using Postgaarden.Crud.Rooms;
using Postgaarden.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgaarden.Model.Bookings
{
    /*
        Developed by Chris Wohlert
    */
    public class BookingHandler
    {
        private IEnumerable<Booking> bookings;
        private RoomHandler roomHandler;

        public BookingHandler(BookingCrud bookingCrud, RoomHandler roomHandler)
        {
            bookings = bookingCrud.Read();
            this.roomHandler = roomHandler;
        }

        /// <summary>
        /// Gets the available rooms.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="size">The size.</param>
        /// <param name="equipment">The equipment.</param>
        /// <returns>Returns a list of availble rooms which passes the requirements.</Room></returns>
        public IEnumerable<Room> GetAvailableRooms(DateTime startTime, DateTime endTime, int size, IEnumerable<string> equipment)
        {
            var roomsByDate = FilterByDate(startTime, endTime).Select(x => x.Room.Id);
            var roomsBySize = roomHandler.Filter(size, true);
            var roomsByEquipment = roomHandler.Filter(equipment);

            var roomsBySizeAndEquipment = roomsBySize.Intersect(roomsByEquipment).Select(x => x.Id);

            var roomsById = roomsBySizeAndEquipment.Except(roomsByDate);

            return
                from a in roomHandler.Rooms
                from b in roomsById
                where a.Id == b
                select a;
        }

        /// <summary>
        /// Gets the available rooms.
        /// </summary>
        /// <param name="booking">The booking to exclude.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="size">The size.</param>
        /// <param name="equipment">The equipment.</param>
        /// <returns></returns>
        public IEnumerable<Room> GetAvailableRooms(Booking booking, DateTime startTime, DateTime endTime, int size, IEnumerable<string> equipment)
        {
            var newList = bookings.Where(x => x.Id != booking.Id);
            var roomsByDate = FilterByDate(newList, startTime, endTime).Select(x => x.Room.Id);
            var roomsBySize = roomHandler.Filter(size, true);
            var roomsByEquipment = roomHandler.Filter(equipment);

            var roomsBySizeAndEquipment = roomsBySize.Intersect(roomsByEquipment).Select(x => x.Id);

            var roomsById = roomsBySizeAndEquipment.Except(roomsByDate);

            return
                from a in roomHandler.Rooms
                from b in roomsById
                where a.Id == b
                select a;
        }

        /// <summary>
        /// Filters the by date.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public IEnumerable<Booking> FilterByDate(DateTime startTime, DateTime endTime)
        {
            return bookings.Where(x => startTime <= x.EndTime && x.StartTime <= endTime);
        }

        /// <summary>
        /// Filters the by date.
        /// </summary>
        /// <param name="bookings">The bookings.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public IEnumerable<Booking> FilterByDate(IEnumerable<Booking> bookings ,DateTime startTime, DateTime endTime)
        {
            return bookings.Where(x => startTime <= x.EndTime && x.StartTime <= endTime);
        }
    }
}
