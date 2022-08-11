using Blog_Managementt.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Models
{
    public class User
    {
        public int ID { get; private set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        protected DateTime Time { get; set; } = DateTime.Now;


        public User(string name, string surname, string email, string password, int id)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            ID = id;
        }

        public User(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            ID = UserRepository.IDCounter;
        }
        public User(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public virtual string GetInfo()
        {
            return Name + " " + Surname;
        }

        public virtual string GetFullInfo()
        {
            return ID + "" + Name + "" + Surname + "" + Email;
        }
    }
}
