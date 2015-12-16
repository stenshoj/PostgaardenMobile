

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Model.Users;
using Postgaarden.Connection;

namespace Postgaarden.Crud.Users
{
    public class SqliteUserCrud : UserCrud
    {
        List<User> users;

        public SqliteUserCrud(DatabaseConnection connection)
        {
            DBConnection = connection;

            users = new List<User>();
            users.Add(new User("4507", "admin", true));
            users.Add(new User("53154", "LoneWolf88"));
            users.Add(new User("64856", "Password1"));
            users.Add(new User("153153", "P@ssw0rd"));
            users.Add(new User("53154", "12345678"));
            users.Add(new User("53154", "drowssap"));
        }

        public override void Create(User entry)
        {

        }

        public override void Delete(User entry)
        {

        }

        public override IEnumerable<User> Read()
        {
            return users;
        }

        public override User Read(User key)
        {
            return users.FirstOrDefault(user => user.Username.Equals(key.Username) && user.Password.Equals(key.Password));
        }

        public override void Update(User entry)
        {
            // UnitTest this
            DBConnection.ExecuteQuery($"UPDATE User SET Password = '{entry.Password}' IsAdministrator = '{entry.IsAdministrator}'");
        }
    }
}
