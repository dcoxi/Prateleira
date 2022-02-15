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
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tb_categoria");
                
            builder.HasMany(p => p.Produtos)
                   .WithMany(c => c.Categorias);
            
            builder.Property(c => c.id)
                   .HasColumnName("id")
                   .HasColumnType("uniqueidentifier")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(c=>c.Descricao)
                   .HasColumnName("descricao")
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();
            
        }
    }
}
