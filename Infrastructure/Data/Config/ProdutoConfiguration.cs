using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Preco).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.ImagemUrl).IsRequired();
            builder.HasOne(p => p.MarcaProduto).WithMany().HasForeignKey(p => p.IdMarcaProduto);
            builder.HasOne(p => p.TipoProduto).WithMany().HasForeignKey(p => p.IdTipoProduto);
        }
    }
}