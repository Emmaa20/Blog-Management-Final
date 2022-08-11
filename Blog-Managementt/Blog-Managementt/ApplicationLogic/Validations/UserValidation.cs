
namespace Blog_Managementt.ApplicationLogic.Validations
{
    using Blog_Managementt.Database.Models;
    using Blog_Managementt.Database.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class UserValidation
    {
        public static bool IsLengthCorrect(string text, int startLengt, int endLength)
        {
            return text.Length >= startLengt && text.Length <= endLength;
        }

        public static bool IsNameValid(string name)
        {
            Regex regex = new Regex(@"^[A-Z]+[a-z]{3,30}");

            return regex.IsMatch(name);
        }

        public static bool IsSurnameValid(string surname)
        {
            Regex regex = new Regex(@"^[A-Z]+[a-z]{4,29}");

            return regex.IsMatch(surname);
        }

        public static bool IsEmailValid(string email)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]{10,20}@code.edu.az$");

            return regex.IsMatch(email);
        }

        public static bool IsPasswordValid(string password)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");

            return regex.IsMatch(password);
        }

        public static bool IsPasswordsMatch(string password, string confirmPassword)
        {
            if (confirmPassword == password)
            {
                return true;
            }
            Console.WriteLine("Password is not match");
            return false;
        }

        public static bool IsLogin(string email, string password)
        {
            foreach (User user in UserRepository.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            Console.WriteLine("The information is incorrect");
            return false;

        }

        public static bool IsUserExitsUnique(string email)
        {
            if (UserRepository.IsUserExitsByEmail(email))
            {
                Console.WriteLine("User already exists");
                return true;
            }
            return false;
        }
    }
}
