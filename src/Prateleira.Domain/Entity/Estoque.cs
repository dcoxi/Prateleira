using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Domain.Entity
{
    public class Estoque
    {
        public Guid Id { get; set; }
        public Produto Produto { get; set; }
        public Guid ProdutoId { get; set; }
        public Qualitativo InfoCompra { get; set; }

    }
}
