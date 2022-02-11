using Prateleira.Domain.Enum;
using System;

namespace Prateleira.Domain.Entity
{
    public class Qualitativo
    {
        public Guid Id { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public decimal PrecoUnidade { get; set; } 
    }
}