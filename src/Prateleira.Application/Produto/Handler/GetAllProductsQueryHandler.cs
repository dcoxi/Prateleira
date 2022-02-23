using MediatR;
using Prateleira.Application.Produto.Query;
using Prateleira.Infrastruture.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Application.Produto.Handler
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entity.Produto>>
    {
        private readonly IGenericRepository<Domain.Entity.Produto> _produtoRepository;

        public GetAllProductsQueryHandler(IGenericRepository<Domain.Entity.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Domain.Entity.Produto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllAsync(noTracking: true, cancellationToken: cancellationToken, includeProperties: "Categorias,Estoque")
                                           .ConfigureAwait(false);
        }
    }
}
