using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Application.Estoque.Query
{
    public class GetAllProdutoEstoqueQuery : IRequest<Domain.Entity.Estoque>
    {
        public Guid IdProduto { get; set; }
    }
}
