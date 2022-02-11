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
        ValueTask<TEntity> Adicionar(TEntity entidade, CancellationToken cancellationToken = default);
        void Actualizar(TEntity entidade);
        void apagar(TEntity entity);
        ValueTask<TEntity> ListarParametros(CancellationToken cancellationToken = default, params object[]);

        IQueryable<TEntity> ListarTudo(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                string includeProperties = "",
                bool noTracking = false, int? take = null, int? skip = null);

        IQueryable<TEntity> ListarTudoAssync(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                string includeProperties = "",
                bool noTracking = false, int? take = null, int? skip = null,
                CancellationToken cancellationToken = default);

        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        

    }
}
