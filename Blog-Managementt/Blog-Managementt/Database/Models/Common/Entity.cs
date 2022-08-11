
namespace Blog_Managementt.Database.Models.Common
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Entity<TId>
    {
        public TId Id { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
