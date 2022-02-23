using MediatR;
using Prateleira.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Application.Estoque
{
    public class CreateEstoqueCommand : IRequest<bool>
    {
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public UnidadeMedida Unidade { get; set; }
        public decimal PrecoUnidade { get; set; }

    }
}
