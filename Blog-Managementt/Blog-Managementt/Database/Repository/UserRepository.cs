using Blog_Managementt.Database.Models;
using Blog_Managementt.Database.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Repository
{
    public class UserRepository : Repository<User, int>
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
        static UserRepository()
        {
            DBcontect.Add(new Admin("Emma", "Kerimova", "emma@code.edu.az", "123321"));
            DBcontect.Add(new Admin("Nigar", "Kerimova", "nigga@code.edu.az", "123321"));
            DBcontect.Add(new User("Elmira", "Kerimova", "emma@code.edu.az", "123321"));
            DBcontect.Add(new User("Nigar", "Kerimova", "nigga@code.edu.az", "123321"));
            DBcontect.Add(new User("Ibrahim", "Kerimov", "ibo@code.edu.az", "123321"));
        }
        

        
        public static User Add(string name, string surname, string email, string password)
        {
            User user = new User(name, surname, email, password);
            DBcontect.Add(user);
            return user;
        }
        
        public static User GetUserByEmail(string email)
        {
            foreach (User user in DBcontect)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }
        public static bool IsUserExitsByEmail(string email)
        {
            foreach (User user in DBcontect)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in DBcontect)
            {
                if (Equals(user.Email, email) && Equals(user.Password, password))
                {
                    return true;
                }

            }
            return false;
        }
        public static User GetUserById(int id)
        {
            foreach (User user in DBcontect)
            {
                if (user.Id == id)
                {
                    return user;

                }
            }
            return null;
        }
        public static User GetUerByEmail(string email)
        {
            foreach (User user in DBcontect)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public static void ShowAdmins()
        {
            Repository<User, int> baseRepo = new Repository<User, int>();
            List<User> users = baseRepo.GetAll();
            foreach (User user in users)
            {
                if (user is Admin)
                {
                    Console.WriteLine(user.GetInfo());
                }
            }

        }
        public static void ShowUsers()
        {
            Repository<User, int> baseRepo = new Repository<User, int>();
            List<User> users = baseRepo.GetAll();
            foreach (User user in users)
            {
                if (user is not Admin)
                {
                    Console.WriteLine(user.GetInfo());
                }

            }
        }
    }
}
