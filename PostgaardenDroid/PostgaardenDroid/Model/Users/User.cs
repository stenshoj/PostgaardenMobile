using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgaarden.Model.Users
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator { get; set; }

        public User(string username, string password, bool isAdministrator = false)
        {
            Username = username;
            Password = password;
            IsAdministrator = isAdministrator;
        }
    }
}
