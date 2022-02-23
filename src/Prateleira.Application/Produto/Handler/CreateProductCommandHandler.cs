using MediatR;
using Prateleira.Application.Produto.Command;
using Prateleira.Infrastruture.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Application.Produto.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entity.Produto>   _productRepository;
        private readonly IGenericRepository<Domain.Entity.Categoria> _categoryRepository;

        public CreateProductCommandHandler(IGenericRepository<Domain.Entity.Produto> productRepository, IGenericRepository<Domain.Entity.Categoria> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.ValidationResult.IsValid)
                return false;

            var categorias = _categoryRepository.GetAll()
                                                .Where(c => request.IdCategorias.Contains(c.Id)).ToList();

            var produto = new Domain.Entity.Produto
            {
                Descricao  = request.Descricao,
                Categorias = categorias
            };

            await _productRepository.AddAsync(produto, cancellationToken).ConfigureAwait(false);
            return await _productRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
