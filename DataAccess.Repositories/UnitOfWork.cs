using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDbContext Context;
        private bool _disposed;
        private readonly Dictionary<Type, object> _repositoriesDictionary;

        public UnitOfWork(IDbContext context)
        {
            Context = context;
            _repositoriesDictionary = new Dictionary<Type, object>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                return;
            }

            Context.Dispose();
            _disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);

            if (!_repositoriesDictionary.ContainsKey(type))
            {
                _repositoriesDictionary.Add(type, new Repository<TEntity>(Context));
            }

            return (IRepository<TEntity>)_repositoriesDictionary[typeof(TEntity)];
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

    }
}
