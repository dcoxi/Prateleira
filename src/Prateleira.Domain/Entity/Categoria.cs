using System;
using System.Collections.Generic;

namespace Prateleira.Domain.Entity
{
    public class Categoria
    {
        public Guid id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; } = default;
    }
}