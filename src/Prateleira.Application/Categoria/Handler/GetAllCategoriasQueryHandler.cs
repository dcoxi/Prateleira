using MediatR;
using Prateleira.Application.Categoria.Query;
using Prateleira.Infrastruture.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Application.Categoria.Handler
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, IEnumerable<Domain.Entity.Categoria>>
    {
        private readonly IGenericRepository<Domain.Entity.Categoria> _categoriaRepositorio;

        public GetAllCategoriasQueryHandler(IGenericRepository<Domain.Entity.Categoria> categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<IEnumerable<Domain.Entity.Categoria>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            return await _categoriaRepositorio.GetAllAsync(
                  noTracking: true,
                  cancellationToken: cancellationToken).ConfigureAwait(false);

        }
    }
}
