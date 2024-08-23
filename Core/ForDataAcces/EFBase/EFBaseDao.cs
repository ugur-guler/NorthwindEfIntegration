using Core.ForEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ForDataAcces.EFBase
{
    public class EFBaseDao<T, Context> : IEntityDao<T>
        where T : class, IEntity, new()
        where Context : DbContext, new()
    {
        public void Add(T entity)
        {
            using (Context context= new Context())
            {
                var ProcessedEntity = context.Entry(entity);
                ProcessedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (Context context = new Context())
            {
                var ProcessedEntity = context.Entry(entity);
                ProcessedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (Context context = new Context())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                return filter== null
                    ? context.Set<T>().ToList()
                    :context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (Context context = new Context())
            {
                var ProcessedEntity = context.Entry(entity);
                ProcessedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
