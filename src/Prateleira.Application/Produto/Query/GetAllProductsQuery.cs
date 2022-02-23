using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Application.Produto.Query
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entity.Produto>>
    {
    }
}
