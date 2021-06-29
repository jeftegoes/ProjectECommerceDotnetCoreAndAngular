using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IGenericRepository<Produto> _protudoRepository;
        private readonly IGenericRepository<MarcaProduto> _marcaProdutoRepository;
        private readonly IGenericRepository<TipoProduto> _tipoProdutoRepository;

        public ProdutoController(IGenericRepository<Produto> protudoRepository,
            IGenericRepository<MarcaProduto> marcaProdutoRepository,
            IGenericRepository<TipoProduto> tipoProdutoRepository)
        {
            _protudoRepository = protudoRepository;
            _marcaProdutoRepository = marcaProdutoRepository;
            _tipoProdutoRepository = tipoProdutoRepository;
        }

        public async Task<ActionResult<IReadOnlyList<Produto>>> GetProdutos()
        {
            var produtos = await _protudoRepository.ListAllAsync();

            return Ok(produtos);
        }

        [HttpGet("marcasProduto")]
        public async Task<ActionResult<IReadOnlyList<Produto>>> GetMarcasProduto()
        {
            var marcasProduto = await _marcaProdutoRepository.ListAllAsync();

            return Ok(marcasProduto);
        }

        [HttpGet("tiposProduto")]
        public async Task<ActionResult<IReadOnlyList<Produto>>> GetTiposProduto()
        {
            var tiposProduto = await _tipoProdutoRepository.ListAllAsync();

            return Ok(tiposProduto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _protudoRepository.GetByIdAsync(id);

            return Ok(produto);
        }
    }
}