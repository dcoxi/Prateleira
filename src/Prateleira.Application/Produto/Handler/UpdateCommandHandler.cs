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
    public class UpdateCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entity.Produto> _productRepository;
        private readonly IGenericRepository<Domain.Entity.Categoria> _categoryRepository;

        public UpdateCommandHandler(IGenericRepository<Domain.Entity.Produto> productRepository, IGenericRepository<Domain.Entity.Categoria> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var produtos = await _productRepository.GetAllAsync(filter: p=>p.Id == request.Id,
                                                                includeProperties: "Categorias")
                                                   .ConfigureAwait(false);
            var produto = produtos.FirstOrDefault()  ?? 
                throw new ArgumentNullException($"Produto {request.Id} não encontrado.");

            produto.Descricao = request.Descricao;
            if (request.IdCategorias.Any())
            {
                var categorias = _categoryRepository.GetAll()
                                                    .Where(c => request.IdCategorias.Contains(c.Id)).ToList();
                produto.Categorias = categorias;
                             
            }
            _productRepository.Update(produto);

            return await _productRepository.CommitAsync(cancellationToken)
                                           .ConfigureAwait(false);

        }
    }
}
