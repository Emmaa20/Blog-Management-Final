using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Repository
{
    internal class BlogRepository
    {
        static Random randomID = new Random();
        private static string _id;
        public static string RandomID
        {
            get
            {
                _id = "BL" + randomID.Next(1, 6);
                return _id;
            }
        }
    }
}
