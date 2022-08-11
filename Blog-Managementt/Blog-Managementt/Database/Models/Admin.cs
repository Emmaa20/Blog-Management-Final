using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Models
{
    public class Admin:User
    {
        public Admin(string name, string surname, string email, string password)
           : base(name, surname, email, password)
        {

        }
        public override string GetInfo()
        {
            return $"Adi : {Name} , Soyadi : {Surname} , Emaili : {Email} , Qeydiyyat tarixi : {Time}";

        }


    }
}
