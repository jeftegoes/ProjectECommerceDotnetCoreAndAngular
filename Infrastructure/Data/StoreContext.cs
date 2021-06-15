using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<MarcaProduto> MarcaProduto { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}