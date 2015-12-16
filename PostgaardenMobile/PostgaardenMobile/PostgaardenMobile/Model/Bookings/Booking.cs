using Postgaarden.Model.Persons;
using Postgaarden.Model.Rooms;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden
{
    [XmlRoot("Booking", IsNullable = false)]
    [XmlInclude(typeof(Person))]
    [XmlInclude(typeof(Room))]
    public class Booking
    {
        [XmlElement("Id", Order = 1)]
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        private double price;
        

        [XmlElement("StartTime", Order =3)]
        public DateTime StartTime
        {
            get;
            set;
        }
        [XmlElement("EndTime", Order =4)]
        public DateTime EndTime
        {
            get;
            set;
        }
        [XmlElement("Room", Order =7)]
        [ForeignKey(typeof(ConferenceRoom)), Column("ConferenceRoom")]
        public Room Room
        {
            get;
            set;
        }
        [XmlElement("Employee", Order = 5)]
        [ForeignKey(typeof(Employee))]
        public Person Employee
        {
            get;
            set;
        }
        [XmlElement("Customer", Order = 6)]
        public Person Customer
        {
            get;
            set;
        }
        [XmlElement(Order = 2)]
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must not be under 0");
                }
                price = value;
            }
        }

        public Booking()
        {
            StartTime = new DateTime();
            EndTime = new DateTime();
        }

        public Boolean SetTime(DateTime startTime, DateTime endTime)
        {
            if (startTime <= endTime)
            {
                this.StartTime = startTime;
                this.EndTime = endTime;

                return true;
            }
            return false;
        }
    }
}