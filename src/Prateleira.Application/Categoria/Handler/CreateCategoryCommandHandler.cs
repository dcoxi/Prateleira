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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoriaCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entity.Categoria> _categoriaRepositorio;

        public CreateCategoryCommandHandler(IGenericRepository<Domain.Entity.Categoria> categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<bool> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            if (!request.ValidationResult.IsValid)
                return false;
            var categoria = new Domain.Entity.Categoria()
            {
                Descricao = request.Descricao
            };

            await _categoriaRepositorio.AddAsync(categoria, cancellationToken)
                                       .ConfigureAwait(false);

            return await _categoriaRepositorio.CommitAsync(cancellationToken)
                                              .ConfigureAwait(false);
        }
    }
}
