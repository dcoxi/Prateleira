using Microsoft.EntityFrameworkCore;
using Prateleira.Domain.Entity;

namespace Prateleira.Infrastruture.Data
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estoque> Estoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
