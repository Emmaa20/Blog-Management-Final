using Blog_Managementt.Database.Enums;
using Blog_Managementt.Database.Models.Common;
using Blog_Managementt.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Models
{
    public class Blog : Entity<string>
    {
        public User FromUser { get; set; }
        public string Title { get; set; }
        public BlogStatus BlogStatus { get; set; }
        public string Content { get; set; }

        public Blog( User fromUser, string title, BlogStatus blogStatus, string content, string id = null)
        {
            if (id != null)

            {
                Id = id;
            }
            else
            {
                Id = BlogRepository.RandomID;
            }
            FromUser = fromUser;
            Title = title;
            BlogStatus = blogStatus;
            Content = content;
            PublishDate = DateTime.Now;


        }
        public string GetBlogFullInfo()
        {
            return "Blog id : " + Id + " " + "Blog user name :" + FromUser.Name + " " + "Blog title :" + Title + " " + "Blog content :" + Content + " " + "Blog creating time :" + PublishDate + "Blog status : " + BlogStatus;
        }
    }
}
