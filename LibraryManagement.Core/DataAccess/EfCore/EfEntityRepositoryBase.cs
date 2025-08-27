using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DataAccess.EfCore
{
    //public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    //    where TEntity : class, IEntity, new()
    //    where TContext : DbContext, new()
    //public class EfEntityRepositoryBase<TEntity, TContext>
    //where TEntity : class
    //where TContext : DbContext, new()
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
    {
        protected readonly TContext _context;
        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<TEntity>().ToList()
            : _context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
