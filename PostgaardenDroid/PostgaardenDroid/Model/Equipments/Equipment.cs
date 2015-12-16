using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Equipments
{
    [XmlType("Equipment")]
    public class Equipment
    {
        [XmlElement("Id", Order = 1)]
        [PrimaryKey]
        public int Id { get; set; }
        [XmlElement("Name", Order = 2)]
        [Ignore]
        public string Name { get; set; }
        public Equipment(string name)
        {
            this.Name = name;
        }
        public Equipment() { }
    }
}
