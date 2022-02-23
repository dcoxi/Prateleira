using MediatR;
using System;
using System.Collections.Generic;

namespace Prateleira.Application.Categoria.Query
{
    public class GetAllCategoriasQuery : IRequest<IEnumerable<Domain.Entity.Categoria>>
    {
       
    }
}
