using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Connection;
using Postgaarden.Model.Equipments;
using Postgaarden.Model.Rooms;
using Postgaarden.Connection;

namespace Postgaarden.Crud.Equipments
{
    /*
        Developed by Martin Hansen
    */
    public class SqliteEquipmentCrud : EquipmentCrud
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqliteEquipmentCrud"/> class.
        /// </summary>
        /// <param name="databaseConnection">The database connection.</param>
        public SqliteEquipmentCrud(DatabaseConnection databaseConnection)
        {
            DBConnection = databaseConnection;
        }

        /// <summary>
        /// Creates the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public override void Create(Equipment entry)
        {
            var createReturn = DBConnection.ExecuteQuery($"INSERT INTO Equipment (Name) VALUES ('{entry.Name}'); SELECT MAX(Id) FROM Equipment;");

            entry.Id = (int)createReturn.First().First();
        }

        /// <summary>
        /// Deletes the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public override void Delete(Equipment entry)
        {
            DBConnection.ExecuteQuery($"DELETE FROM Equipment WHERE Id = {entry.Id};");
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>
        /// Returns every T from the database connection
        /// </returns>
        public override IEnumerable<Equipment> Read()
        {
            var equipmentObjects = DBConnection.ExecuteQuery("SELECT Id,Name FROM Equipment;");

            return equipmentObjects.Select(o => new Equipment((string)o.ElementAt(1)) {Id = Convert.ToInt32(o.ElementAt(0))});
        }

        /// <summary>
        /// Reads the specified room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override IEnumerable<Equipment> Read(Room room)
        {
            var equipments = DBConnection.ExecuteQuery(
                $"SELECT Equipment.Id AS EquipmentId, Equipment.Name AS EquipmentName FROM Equipment JOIN ConferenceRoom ON Equipment.ConferenceRoomId = ConferenceRoom.Id WHERE ConferenceRoom.Id = {room.Id};");

            return equipments.Select(o => new Equipment((string)o.ElementAt(1)) { Id = Convert.ToInt32(o.ElementAt(0)) });
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// Returns every T from the database connection
        /// </returns>
        public override Equipment Read(int key)
        {
            var readReturn = DBConnection.ExecuteQuery($"SELECT Id,Name FROM Equipment WHERE Id = {key};").First();

            return new Equipment((string)readReturn.ElementAt(1)) { Id = (int)readReturn.ElementAt(0) };
        }

        /// <summary>
        /// Updates the specified equipment.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        /// <param name="room">The room.</param>
        public override void Update(Equipment equipment ,Room room)
        {
            DBConnection.ExecuteQuery($"UPDATE Equipment SET ConferenceRoomId = {room.Id} WHERE Id = {equipment.Id};");
        }

        /// <summary>
        /// Updates the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public override void Update(Equipment entry)
        {
            DBConnection.ExecuteQuery($"UPDATE Equipment SET Name = '{entry.Name}' WHERE Id = {entry.Id};");
        }
    }
}
