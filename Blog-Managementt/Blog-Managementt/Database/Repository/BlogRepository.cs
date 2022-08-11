using Blog_Managementt.Database.Models;
using Blog_Managementt.Database.Repository.Common;
using System;

namespace Blog_Managementt.Database.Repository
{
    internal class BlogRepository : Repository<Blog,string>
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
