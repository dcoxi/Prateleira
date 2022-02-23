using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prateleira.Domain.Entity;

namespace Prateleira.Infrastruture.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produto")
                   .HasOne(e => e.Estoque)
                   .WithOne(p=>p.Produto)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey<Estoque>(r => r.ProdutoId);

            builder.HasMany(c => c.Categorias)
                   .WithMany(p => p.Produtos);

            builder.Property(p => p.Descricao)
                   .HasColumnName("Id")
                   .HasColumnType("uniqueidentifier")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .HasColumnName("descricao")
                   .HasColumnType("varchar")
                   .HasMaxLength(300)
                   .IsRequired();
        }
    }
}
