using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<IReadOnlyList<Produto>> GetProdutosAsync();
        Task<IReadOnlyList<MarcaProduto>> GetMarcasProdutoAsync();
        Task<IReadOnlyList<TipoProduto>> GetTiposProdutoAsync();
    }
}