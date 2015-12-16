using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Persons
{
    [XmlType("Person")]
    [XmlInclude(typeof(Employee)), XmlInclude(typeof(Customer))]
    public abstract class Person
    {
        //Created by Jens Kloster
        
        private string name;
        private string emailaddress;

        [XmlElement("Name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [XmlElement("EmailAddress")]
        public string EmailAddress
        {
            get
            {
                return emailaddress;
            }
            set
            {
                emailaddress = value;
            }
        }
    }
}
