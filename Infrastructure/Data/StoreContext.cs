using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext
    {
        public class LojaContext : DbContext
        {
            public DbSet<Produto> Produto { get; set; }

            public LojaContext(DbContextOptions options) : base(options)
            {
            }
        }
    }
}