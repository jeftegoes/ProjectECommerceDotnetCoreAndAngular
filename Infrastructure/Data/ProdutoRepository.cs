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
            return await _context.Produto.FindAsync(id);
        }

        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            return await _context.Produto.ToListAsync();
        }
    }
}