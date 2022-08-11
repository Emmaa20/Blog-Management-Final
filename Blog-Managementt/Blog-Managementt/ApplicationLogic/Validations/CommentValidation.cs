
namespace Blog_Managementt.ApplicationLogic.Validations
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class CommentValidation
    {
        public static bool IsValidComment(string content)
        {
            if (content.Length >= 10 & content.Length <= 35)
            {
                return true;
            }
            Console.WriteLine("Length sould be between 10 and 35");
            return false;
        }
    }
}
