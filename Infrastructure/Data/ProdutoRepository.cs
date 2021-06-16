using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LojaContext _context;

        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produto
            .Include(p => p.TipoProduto)
            .Include(p => p.MarcaProduto)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            return await _context.Produto
            .Include(p => p.TipoProduto)
            .Include(p => p.MarcaProduto)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<TipoProduto>> GetTiposProdutoAsync()
        {
            var tiposProduto = await _context.TipoProduto.ToListAsync();

            return tiposProduto;
        }

        public async Task<IReadOnlyList<MarcaProduto>> GetMarcasProdutoAsync()
        {
            var marcasProduto = await _context.MarcaProduto.ToListAsync();

            return marcasProduto;
        }
    }
}