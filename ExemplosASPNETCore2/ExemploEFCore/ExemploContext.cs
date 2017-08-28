using Microsoft.EntityFrameworkCore;

namespace ExemploEFCore
{
    public class ExemploContext : DbContext
    {
        public DbSet<Cotacao> Cotacoes { get; set; }

        public ExemploContext(DbContextOptions<ExemploContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>()
                .HasKey(c => c.Sigla);

            // Owned entity/Table Splitting com a mesma tabela
            modelBuilder.Entity<Cotacao>()
                .OwnsOne(c => c.Valor);
        }
    }
}