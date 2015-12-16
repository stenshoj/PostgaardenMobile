using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Rooms
{
    /*
        Developed by Chris Wohlert
    */
    [XmlType("ConferenceRoom")]
    public class ConferenceRoom : Room
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("Name")]
        public override string Name
        {
            get
            {
                return "Mødelokale " + this.Id;
            }
        }
    }
}
