using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Postgaarden.Model.Persons
{
    [XmlType("Customer")]
    public class Customer : Person
    {
        //Created by Jens Kloster

        private string cvr;
        private string companyName;
        
        [XmlElement("CVR")]
        public string Cvr
        {
            get
            {
                return cvr;
            }
            set
            {
                cvr = value;
            }
        }

        [XmlElement("CompanyName")]
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
            }
        }

    }
}

