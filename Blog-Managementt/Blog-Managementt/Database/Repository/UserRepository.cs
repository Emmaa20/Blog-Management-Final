using Blog_Managementt.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Repository
{
    internal class UserRepository
    {
        private static int _idcounter;

        public static int IDCounter
        {
            get
            {
                _idcounter++;
                return _idcounter;
            }

        }

        public static List<User> Users { get; set; } = new List<User>()
        {
            new User ("Elmira","Kerimova","emma@gmail.com","123"),
            new User("Nigar","Kerimova","nigga@gmail.com","1234"),
            new User("Ibrahim","Kerimov","ibo@gmail.com","12345"),

        };
        public static User Add(string name, string surname, string email, string password)
        {
            User user = new User(name, surname, email, password);
            Users.Add(user);
            return user;
        }
        public static User Add(string name, string surname, string email, string password, int id)
        {
            User user = new User(name, surname, email, password, id);
            Users.Add(user);
            return user;
        }
    }
}
