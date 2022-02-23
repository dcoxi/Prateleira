using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Application.Produto.Command
{
    public class UpdateProductCommand : IRequest<bool>
    {

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid[] IdCategorias { get; set; }

    }
}
