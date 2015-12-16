using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Connection;
using Postgaarden.Model.Rooms;
using Postgaarden.Connection.Sqlite;
using Postgaarden.Model.Equipments;
using Postgaarden.Crud.Equipments;

namespace Postgaarden.Crud.Rooms
{
    /*
        Developed by Chris Wohlert
    */
    public class SqliteRoomCrud : RoomCrud
    {
        private EquipmentCrud equipmentCrud;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqliteRoomCrud"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public SqliteRoomCrud(DatabaseConnection connection, EquipmentCrud equipmentCrud)
        {
            this.DBConnection = connection;
            this.equipmentCrud = equipmentCrud;
        }

        /// <summary>
        /// Creates the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public override void Create(Room entry)
        {
            DBConnection.ExecuteQuery($"INSERT INTO ConferenceRoom (Id, Capacity) VALUES ({entry.Id}, {entry.Size});");
        }

        /// <summary>
        /// Deletes the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public override void Delete(Room entry)
        {
            DBConnection.ExecuteQuery($"DELETE FROM ConferenceRoom WHERE Id = {entry.Id};");
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>
        /// Returns every T from the database connection
        /// </returns>
        public override IEnumerable<Room> Read()
        {
            var rooms = DBConnection.ExecuteQuery("SELECT Id, Capacity FROM ConferenceRoom;");
            return ParseToRoom(rooms);
        }

        public override Room Read(Booking booking)
        {
            var room = DBConnection.ExecuteQuery(
                $"SELECT r.Id AS RoomId, Capacity FROM ConferenceRoom AS r "+
                $"JOIN Booking ON r.Id = Booking.ConferenceRoomId "+
                $"WHERE Booking.Id = {booking.Id};"
                );

            return ParseToRoom(room).FirstOrDefault();
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// Returns every T from the database connection
        /// </returns>
        public override Room Read(int key)
        {
            var room = DBConnection.ExecuteQuery($"SELECT Id, Capacity FROM ConferenceRoom WHERE Id = {key};");
            return ParseToRoom(room).First();
        }

        /// <summary>
        /// Updates the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public override void Update(Room entry)
        {
            DBConnection.ExecuteQuery($"UPDATE ConferenceRoom SET Capacity = {entry.Size} WHERE Id = {entry.Id};");
        }

        private IEnumerable<Room> ParseToRoom(IEnumerable<IEnumerable<object>> objectToParse)
        {
            foreach (var row in objectToParse)
            {
                Room room = new ConferenceRoom();
                room.Id = Convert.ToInt32(row.ElementAt(0));
                room.Size = Convert.ToInt32(row.ElementAt(1));
                foreach (var e in equipmentCrud.Read(room))
                {
                    room.Equipments.Add(e);
                    equipmentCrud.Update(e, room);
                }
                yield return room;
            }
        }
    }
}
