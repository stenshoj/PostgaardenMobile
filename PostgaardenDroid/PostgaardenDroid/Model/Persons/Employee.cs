using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Persons
{
    [XmlType("Employee")]
    public class Employee : Person
    {
        //Created by Jens Kloster

        private int id;
        [XmlElement("Id")]
        [PrimaryKey]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
