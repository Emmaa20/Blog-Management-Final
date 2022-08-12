using Blog_Managementt.Database.Models;
using Blog_Managementt.Database.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Repository
{
    public class CommentRepository : Repository<Comment, int>
    { public static BlogRepository blogRepo = new BlogRepository();
        static CommentRepository()
        {
            DBcontect.Add(new Comment(UserRepository.GetUserByEmail("emma@code.edu.az"), blogRepo.GetById("BL11111"), "You are beautiful babe"));
            DBcontect.Add(new Comment(UserRepository.GetUserByEmail("nigga@code.edu.az"), blogRepo.GetById("BL11112"), "Amazing!"));
            DBcontect.Add(new Comment(UserRepository.GetUserByEmail("ibo@code.edu.az"), blogRepo.GetById("BL11113"), "Machine"));

        }
    }
}
