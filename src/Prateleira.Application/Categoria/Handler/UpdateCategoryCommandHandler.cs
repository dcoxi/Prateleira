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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        public readonly IGenericRepository<Domain.Entity.Categoria> _genericRepository;

        public UpdateCategoryCommandHandler(IGenericRepository<Domain.Entity.Categoria> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _genericRepository.GetByKeysAsync(cancellationToken, request.Id)
                                                    .ConfigureAwait(false);
            categoria.Descricao = request.Descricao;
            _genericRepository.Update(categoria);

            return await  _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
