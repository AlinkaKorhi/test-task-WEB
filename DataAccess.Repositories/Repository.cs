using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IDbContext Context;

        private readonly DbSet<TEntity> _dbSet;

        protected IQueryable<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public Repository(IDbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entityEntry = await _dbSet.AddAsync(entity);

            return entityEntry.Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            if (!_dbSet.Local.Contains(entity))
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity>>[] includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            return await query.ToListAsync();
        }

        public TEntity GetEntityById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var updatedEntityEntry = _dbSet.Update(entity);

            return updatedEntityEntry.Entity;
        }
    }
}
