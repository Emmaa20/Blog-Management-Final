
namespace Blog_Managementt.Database.Models
{
using Blog_Managementt.Database.Models.Common;
using Blog_Managementt.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
        public class Inbox : Entity<int>
        {
            public User User { get; set; }
            public string Message { get; set; }
            public Inbox(string message, User user, int? id = null)
            {
                Message = message;
                User = user;
                if (id != null)
                {
                    Id = id.Value;
                }
                else
                {
                    Id = UserRepository.IDCounter;
                }
            }
        }
    }

