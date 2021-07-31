using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        void Dispose();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task SaveAsync();
    }
}
