using Postgaarden.Crud.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgaarden.Model.Users
{
    public class LoginHandler
    {
        /// <summary>
        /// Gets or sets the user crud.
        /// </summary>
        /// <value>
        /// The user crud.
        /// </value>
        public UserCrud UserCrud { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="LoginHandler"/> class.
        /// </summary>
        /// <param name="userCrud">The user crud.</param>
        public LoginHandler(UserCrud userCrud)
        {
            UserCrud = userCrud;
        }
        
        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Returns true if the user provided the correct password, false if not.</returns>
        public bool Login(User user)
        {
            var crudUser = UserCrud.Read(user);
            if (crudUser != null)
            {
                crudUser.Password.Equals(user.Password);
                return true;
            }
            return false;
        }

        public bool IsAdministrator(User user)
        {
            var crudUser = UserCrud.Read(user);
            return crudUser.IsAdministrator;
        }
    }
}
