using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Infrastruture.Data.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> AddAsync(TEntity entidade, CancellationToken cancellationToken = default);
        void Update(TEntity entidade);
        void Delete(TEntity entity);
        ValueTask<TEntity> GetByKeysAsync(CancellationToken cancellationToken = default, params object[] keys);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                string includeProperties = "",
                bool noTracking = false, int? take = null, int? skip = null);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                string includeProperties = "",
                bool noTracking = false, int? take = null, int? skip = null,
                CancellationToken cancellationToken = default);

        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        

    }
}
