using MediatR;
using Prateleira.Application.Estoque.Query;
using Prateleira.Infrastruture.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Application.Estoque.Handler
{
    public class GetAllProdutoEstoqueQueryHandler : IRequestHandler<GetAllProdutoEstoqueQuery, Domain.Entity.Estoque>
    {
        private readonly IGenericRepository<Domain.Entity.Estoque> _estoqueRepository;

        public GetAllProdutoEstoqueQueryHandler(IGenericRepository<Domain.Entity.Estoque> estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<Domain.Entity.Estoque> Handle(GetAllProdutoEstoqueQuery request, CancellationToken cancellationToken)
        {
            var estoqueProdutos = await _estoqueRepository.GetAllAsync(filter: x => x.ProdutoId == request.IdProduto,
                                                                 cancellationToken: cancellationToken)
                                                    .ConfigureAwait(false);
            return estoqueProdutos.FirstOrDefault();
        }
    }
}
