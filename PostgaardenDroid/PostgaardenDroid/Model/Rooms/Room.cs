using Postgaarden.Model.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Rooms
{
    /*
        Chris Wohlert
    */
    [XmlType("Room")]
    [XmlInclude(typeof(Equipment)), XmlInclude(typeof(ConferenceRoom))]
    public abstract class Room
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlElement("Id", Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("Name", Order = 3)]
        public abstract String Name{ get; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [XmlElement("Size", Order = 2)]
        public int Size { get; set; }

        /// <summary>
        /// Gets the equipments.
        /// </summary>
        /// <value>
        /// The equipments.
        /// </value>
        [XmlArray("Equipments", Order = 3)]
        [XmlArrayItem("Equipment")]
        public List<Equipment> Equipments { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        protected Room()
        {
            Equipments = new List<Equipment>();
        }
    }
}
