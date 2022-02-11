using System;
using System.Collections.Generic;

namespace Prateleira.Domain.Entity
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
        public Estoque Estoque { get; set; } = default
    }
}