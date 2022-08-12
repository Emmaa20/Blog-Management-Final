using Blog_Managementt.Database.Enums;
using Blog_Managementt.Database.Models;
using Blog_Managementt.Database.Repository.Common;
using System;

namespace Blog_Managementt.Database.Repository
{
    public class BlogRepository : Repository<Blog, string>
    {
        static Random randomID = new Random();

        private static string _id;
        public static string RandomID
        {
            get
            {
                _id = "BL" + randomID.Next(100, 600);
                return _id;
            }
        }

        static BlogRepository()
        {
            DBcontect.Add(new Blog(UserRepository.GetUserByEmail("emma@code.edu.az"), "Make Up", BlogStatus.Created, "Amazing", "BL11111"));
            DBcontect.Add(new Blog(UserRepository.GetUserByEmail("nigga@code.edu.az"), "School", BlogStatus.Created, "high school", "BL11112"));
            DBcontect.Add(new Blog(UserRepository.GetUserByEmail("ibo@code.edu.az"), "Machine", BlogStatus.Created, "Mercedes", "BL11113"));
        }


    }
}
