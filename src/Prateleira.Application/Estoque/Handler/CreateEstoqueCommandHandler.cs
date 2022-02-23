using MediatR;
using Prateleira.Infrastruture.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Application.Estoque.Handler
{
    public class CreateEstoqueCommandHandler : IRequestHandler<CreateEstoqueCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entity.Estoque> _estoqueRepository;
        private readonly IGenericRepository<Domain.Entity.Produto> _productRepository;

        public CreateEstoqueCommandHandler(IGenericRepository<Domain.Entity.Estoque> estoqueRepository, IGenericRepository<Domain.Entity.Produto> produtoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _productRepository = produtoRepository;
        }

        public async Task<bool> Handle(CreateEstoqueCommand request, CancellationToken cancellationToken)
        {
            var produto = await _productRepository.GetByKeysAsync(cancellationToken, request.IdProduto)
                        ?? throw new ArgumentException("Id do produto inválido!");
            var estoque = new Domain.Entity.Estoque
            {
                ProdutoId = produto.Id,
                InfoCompra = new Domain.Entity.Qualitativo
                {
                    PrecoUnidade = request.PrecoUnidade,
                    Quantidade = request.Quantidade,
                    UnidadeMedida = request.Unidade
                }
            };

            await _estoqueRepository.AddAsync(estoque, cancellationToken).ConfigureAwait(false);
            return await _estoqueRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
