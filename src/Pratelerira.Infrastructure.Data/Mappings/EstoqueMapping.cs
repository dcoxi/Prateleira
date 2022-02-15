using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prateleira.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Infrastruture.Data.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("tb_estoque")
                   .OwnsOne(c => c.InfoCompra)
                   .Property(p => p.PrecoUnidade)
                   .HasColumnName("preco_unitario")
                   .HasPrecision(16,4);

            builder.OwnsOne(i => i.InfoCompra)
                   .Property(q => q.Quantidade)
                   .HasColumnName("quantidade");

            builder.HasOne(p => p.Produto)
                   .WithOne(e => e.Estoque)
                   .HasForeignKey<Estoque>(e => e.ProdutoId);
                   
        }
    }
}
