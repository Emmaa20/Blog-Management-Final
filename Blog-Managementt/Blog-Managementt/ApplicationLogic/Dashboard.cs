
namespace Blog_Managementt.ApplicationLogic
{
    using Blog_Managementt.Database.Enums;
    using Blog_Managementt.Database.Models;
    using Blog_Managementt.Database.Repository;
    using Blog_Managementt.Database.Repository.Common;
    using Blog_Managementt.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static partial class Dashboard
    {
        public static User CurrentUser { get; set; }
        public static void AdminPanel()
        {
            Console.WriteLine("/show-users");
            Console.WriteLine("/show-admins");
            Console.WriteLine("/show-auditing-blogs");
            Console.WriteLine("/approve-blog");
            Console.WriteLine("/reject-blog");
            Console.WriteLine("/logOut");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Please enter command : ");
                string command = Console.ReadLine();

                if (command == "/show-admins")
                {
                    UserRepository.ShowAdmins();
                }

                else if (command == "/logOut")
                {
                    Program.Main(new string[] { });
                    break;
                }

                else if (command == "/show-users")
                {
                    UserRepository.ShowUsers();

                }

                else if (command == "/show-auditing-blogs")
                {
                    Authentication.ShowAuditingBlogs();
                }

                else if (command == "/approve-blog")
                {
                    Authentication.ApproveBlog();

                }

                else if (command == "/reject-blog")
                {
                    Authentication.RejectBlog();
                }

                else
                {
                    Console.WriteLine("Command not found");
                }
            }
        }
    }

    public static partial class Dashboard
    {
        public static void UserPanel(string email)
        {
            

            User user = UserRepository.GetUerByEmail(email);
            Console.WriteLine($"user succesfully joined : {user.GetInfo()}");

            Console.WriteLine("/inbox");
            Console.WriteLine("/blogs");
            Console.WriteLine("/add-comment");
            Console.WriteLine("/delete-blog");
            Console.WriteLine("/add-blog");

            while (true)
            {
                Console.WriteLine("");
                Console.Write("Please enter command: ");
                string command = Console.ReadLine();

                if (command == "/inbox")
                {
                    Authentication.Inbox();
                }

                else if (command == "/logOut")
                {
                    Program.Main(new string[] { });

                }

                else if (command == "/add-comment")
                {
                    Authentication.AddComment();
                }

                else if (command == "/blogs")
                {
                    Authentication.Blogs();
                }

                else if (command == "/add-blog")
                {
                    Authentication.AddBlog();
                }

                else if (command == "/delete-blog")
                {
                    Authentication.DeleteBlog();
                }
            }
        }
    }
}












