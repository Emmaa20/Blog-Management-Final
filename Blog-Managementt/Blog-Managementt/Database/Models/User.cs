using Blog_Managementt.Database.Models.Common;
using Blog_Managementt.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Models
{
    public class User : Entity<int>  //The user model is ready
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        protected DateTime Time { get; set; } = DateTime.Now;

        public User(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Id = UserRepository.IDCounter;
        }

        public virtual string GetInfo()
        {
            return Name + " " + Surname;
        }

    }
}
