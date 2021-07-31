using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);

        void Delete(TEntity entity);

        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity>>[] includes);

        TEntity Update(TEntity entity);

        TEntity GetEntityById(int id);
    }
}
