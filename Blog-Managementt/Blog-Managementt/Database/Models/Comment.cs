using Blog_Managementt.Database.Models.Common;
using Blog_Managementt.Database.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Models
{

    public class Comment : Entity<int>
    {
        public User FromUser { get; set; }
        public Blog Blog { get; set; }
        public string Content { get; set; }

        public Comment(User fromUser,Blog blog ,string content, int? id = null)

        {
            FromUser = fromUser;
            Content = content;
            Blog = blog;
            if (id != null)
            {
                Id = id.Value;

            }
            else
            {
                Id = UserRepository.IDCounter;
            }
            
        }
        public override string ToString()
        {
            return $"{FromUser.Name} {FromUser.Surname} {Content}";
        }
    }
}

