using Blog_Managementt.ApplicationLogic.Validations;
using Blog_Managementt.Database.Enums;
using Blog_Managementt.Database.Models;
using Blog_Managementt.Database.Repository;
using Blog_Managementt.Database.Repository.Common;
using System;
using System.Collections.Generic;

namespace Blog_Managementt.ApplicationLogic
{
    public class Authentication
    {
        public static User CurrentUser { get; set; }
        public static void Register()
        {
            Console.WriteLine();
            Console.Write("Name :");
            string name = Console.ReadLine();

            while (!UserValidation.IsNameValid(name))
            {
                Console.Write("Write name again :");
                name = Console.ReadLine();
            }

            Console.Write("Surname :");
            string surname = Console.ReadLine();

            while (!UserValidation.IsSurnameValid(surname))
            {
                Console.Write("Write surname again : ");
                surname = Console.ReadLine();
            }

            Console.Write("Email (Nümünə : mahmood@code.edu.az, revanhello@code.edu.az) :");
            string email = Console.ReadLine();

            while (!UserValidation.IsEmailValid(email))
            {
                Console.Write("Write email again :");
                email = Console.ReadLine();
            }

            Console.Write("Password :");
            string password = Console.ReadLine();

            Console.Write("Confirm Password : ");
            string confirmPassword = Console.ReadLine();


            while (!(UserValidation.IsPasswordValid(password) && UserValidation.IsPasswordsMatch(password, confirmPassword)))
            {
                Console.Write("Write password again :");
                password = Console.ReadLine();

                Console.Write("Write confirm password again :");
                confirmPassword = Console.ReadLine();
            }

            UserRepository.Add(name, surname, email, password);
            Console.WriteLine("You successfully registered, now you can login with your new account!");
        }

        public static void Login()
        {
            Console.Write("Enter email:");
            string email = Console.ReadLine();

            Console.Write("Enter password:");
            string password = Console.ReadLine();

            if (UserRepository.GetUserByEmailAndPassword(email, password))
            {
                User user = UserRepository.GetUerByEmail(email);
                Dashboard.CurrentUser = user;
                if (user is Admin)
                {
                    Dashboard.AdminPanel();
                }
                if (user is User)
                {
                    Dashboard.UserPanel(email);
                }
            }
        }
        public static string GetComment()
        {
            Console.Write("Please enter comment content: ");
            string commentContent = Console.ReadLine();
            while (!CommentValidation.IsValidComment(commentContent))
            {
                Console.Write("Please enter comment content again: ");
                commentContent = Console.ReadLine();
            }
            return commentContent;
        }
        public static string GetBlogTitle()
        {
            Console.Write("Please enter blog title: ");
            string title = Console.ReadLine();
            while (!BlogValidation.IsValidTitle(title))
            {
                Console.Write("Please enter blog title again: ");
                title = Console.ReadLine();
            }
            return title;

        }
        public static string GetBlogContent()
        {
            Console.Write("Please enter blog content: ");
            string blogContent = Console.ReadLine();
            while (!BlogValidation.IsValidContent(blogContent))
            {
                Console.Write("Please enter blog content again: ");
                blogContent = Console.ReadLine();
            }
            return blogContent;

        }

        public static void ShowAuditingBlogs()
        {
            BlogRepository blogRepo = new BlogRepository();

            List<Blog> blogs = blogRepo.GetAll(b => b.BlogStatus == BlogStatus.Created);
            foreach (Blog blog in blogs)
            {
                Console.WriteLine(blog.GetBlogFullInfo());
            }
        }
        public static void ApproveBlog()
        {
            BlogRepository blogRepo = new BlogRepository();
            InboxRepository inboxRepo = new InboxRepository();

            Console.Write("Please enter blog's Blog Code: ");
            string blogID = Console.ReadLine();
            Blog blog = blogRepo.GetById(blogID);
            if (blog != null && blog.BlogStatus == BlogStatus.Created)
            {
                blog.BlogStatus = BlogStatus.Approve;
                Inbox message = new Inbox($"This blog {blog.Id} Approved by Admin", blog.FromUser);
                inboxRepo.Add(message);
                Console.WriteLine("Blog has been aproved");

            }


        }
        public static void RejectBlog()
        {
            Repository<User, int> baserepo = new Repository<User, int>();
            BlogRepository blogRepo = new BlogRepository();
            InboxRepository inboxRepo = new InboxRepository();

            Console.WriteLine("Please enter blog's BlogCode: ");
            string blogCode = Console.ReadLine();
            Blog blog = blogRepo.GetById(blogCode);
            if (blog.BlogStatus == BlogStatus.Created)
            {
                blog.BlogStatus = BlogStatus.Approve;
                Inbox message = new Inbox($"This blog {blog.Id} Rejected by Admin", blog.FromUser);
                inboxRepo.Add(message);
                Console.WriteLine("Blog has been Rejected");

            }

        }
        public static void AddComment()
        {
            CommentRepository commentRepo = new CommentRepository();


            Console.Write("Please enter blog code: ");
            string blogCode = Console.ReadLine();
            BlogRepository blogReposity = new BlogRepository();
            Blog blog = blogReposity.GetById(blogCode);
            if (blog != null)
            {
                Comment comments = new Comment(CurrentUser, blog, Authentication.GetComment());
                commentRepo.Add(comments);
                Console.WriteLine("Comment added succesfully");

            }
            else
            {
                Console.WriteLine("Blog Not Found");
            }
        }
        public static void Blogs()
        {

            BlogRepository blogRepo = new BlogRepository();

            List<Blog> blogs = blogRepo.GetAll();
            if (blogs != null)
            {
                int count = 1;
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine($"{count}." + blog.GetBlogFullInfo());
                    count++;
                }
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
        public static void AddBlog()
        {
            BlogRepository blogRepo = new BlogRepository();
            Blog blog = new Blog(CurrentUser, Authentication.GetBlogTitle(), BlogStatus.Created, Authentication.GetBlogContent());
            blogRepo.Add(blog);
            Console.WriteLine("Blog added succesfully");
        }
        public static void DeleteBlog()
        {
            CommentRepository commentRepo = new CommentRepository();
            BlogRepository blogRepo = new BlogRepository();

            Console.Write("Please enter blog's Blog code : ");
            string blogCode = Console.ReadLine();
            Blog blog = blogRepo.GetById(blogCode);
            List<Comment> comments = commentRepo.GetAll(c => c.Blog == blog);
            if (blog.FromUser != CurrentUser)
            {
                Console.WriteLine("This is not your's Blog");
            }
            else if (blog == null)
            {
                Console.WriteLine("Blog  not found");
            }

            else if (blog.FromUser == CurrentUser)
            {
                blogRepo.Delete(blog);
                foreach (Comment comment in comments)
                {
                    commentRepo.Delete(comment);
                }
                Console.WriteLine("Blog has been deleted");




            }

        }

        public static void Inbox()
        {

        }
    }
}
