using Prateleira.Domain.Enum;
using System;

namespace Prateleira.Domain.Entity
{
    public class Qualitativo
    {
        public UnidadeMedida UnidadeMedida { get; set; }
        public decimal PrecoUnidade { get; set; } 
        public int Quantidade { get; set; }
    }
}