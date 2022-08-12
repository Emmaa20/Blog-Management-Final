
namespace Blog_Managementt.ApplicationLogic.Services
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Blog_Managementt.Database.Enums;
    using Blog_Managementt.Database.Models;
    using Blog_Managementt.Database.Repository;
    internal class BlogService
    {
        public static BlogRepository blogs = new BlogRepository();
        public static CommentRepository comments = new CommentRepository();
        public static void ShowBlogsWithComment()
        {
            BlogRepository blogRepo = new BlogRepository();
            CommentRepository commentRepo = new CommentRepository();
            List<Blog> blogs = blogRepo.GetAll();
            foreach (Blog blog in blogs)
            {
                if (blog.BlogStatus == BlogStatus.Approve)
                {
                    Console.WriteLine(blog.GetBlogFullInfo());
                    int counter = 1;
                    foreach (Comment comment in commentRepo.GetAll(c => c.Blog == blog))
                    {
                        Console.WriteLine($"{counter}" + comment.ToString());
                        counter++;
                    } 
                }
            }

        }
        public static void ShowFilteredBlogsWithComments()
        {
            Console.WriteLine("/Title");
            Console.WriteLine("Lastname");
            Console.Write("Enter suitable command: ");
            string command = Console.ReadLine();
            if (command == "/Title")
            {
                Console.Write("Please enter blog's title: ");
                string title = Console.ReadLine();
                int count = 1;
                foreach (Blog blog in blogs.GetAll())
                {
                    if (blog.Title == title && blog.BlogStatus == BlogStatus.Approve)
                    {
                        Console.WriteLine(blog.GetBlogFullInfo());

                    }
                    foreach (Comment comment in comments.GetAll(c => c.Blog == blog))
                    {


                        Console.WriteLine($"{count}" + comment.ToString());
                        count++;

                    }

                }




            }
            if (command == "Lastname")
            {
                Console.Write("Please enter owener's lastname: ");
                string lastName = Console.ReadLine();
                int count = 1;
                foreach (Blog blog in blogs.GetAll())
                {
                    if (blog.FromUser.Surname == lastName && blog.BlogStatus == BlogStatus.Approve)
                    {
                        Console.WriteLine(blog.GetBlogFullInfo());

                    }
                    foreach (Comment comment in comments.GetAll())
                    {
                        if (comment.Blog == blog)
                        {
                            Console.WriteLine($"{count}" + comment.ToString());
                            count++;
                        }
                    }

                }
            }



        }
        public static void FindBlogByCode()
        {
            Console.Write("Please enter blog code: ");
            string blogCode = Console.ReadLine();
            Blog blog = blogs.GetById(blogCode);
            if (blog.BlogStatus == BlogStatus.Approve)
            {
                Console.WriteLine(blog.GetBlogFullInfo());
            }



        }

    }
}

