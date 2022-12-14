using Blog_Managementt.Database.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Managementt.Database.Repository.Common
{
    public class Repository<TEntity, Tid>
        where TEntity : Entity<Tid>
    {
        protected static List<TEntity> DBcontect { get; set; } = new List<TEntity>();
        public TEntity Add(TEntity entry)
        {
            DBcontect.Add(entry);
            return entry;
        }
        public List<TEntity> GetAll()
        {
            return DBcontect;
        }
        public List<TEntity> GetAll(Predicate<TEntity> predicate)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (TEntity entity in DBcontect)
            {
                if (predicate(entity))
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }
        public TEntity GetById(Tid id)
        {
            foreach (TEntity entry in DBcontect)
            {
                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }
            return default(TEntity);
        }
        public void Delete(TEntity entry)
        {
            DBcontect.Remove(entry);
        }
    }
}
