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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {

        private readonly IGenericRepository<Domain.Entity.Produto> _produtoGenerico;

        public DeleteProductCommandHandler(IGenericRepository<Domain.Entity.Produto> produtoGenerico)
        {
            _produtoGenerico = produtoGenerico;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoGenerico.GetByKeysAsync(cancellationToken,request.Id)
                                                 .ConfigureAwait(false);

            _produtoGenerico.Delete(produtos);
            return await _produtoGenerico.CommitAsync(cancellationToken)
                                   .ConfigureAwait(false);
        }
    }
}
