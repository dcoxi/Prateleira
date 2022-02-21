using MediatR;
using Prateleira.Application.Categoria.Command;
using Prateleira.Infrastruture.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Application.Categoria.Handler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entity.Categoria> _genericRepository; 
        
        public DeleteCategoryCommandHandler(IGenericRepository<Domain.Entity.Categoria> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _genericRepository.GetByKeysAsync(cancellationToken, request.Id)
                                                    .ConfigureAwait(false);

            _genericRepository.Delete(categoria);

            return await _genericRepository.CommitAsync(cancellationToken)
                                           .ConfigureAwait(false);
        }
    }
}
