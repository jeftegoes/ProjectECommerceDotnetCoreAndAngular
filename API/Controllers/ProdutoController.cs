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
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult<IReadOnlyList<Produto>>> GetProdutos()
        {
            var produtos = await _repository.GetProdutosAsync();

            return Ok(produtos);
        }

        [HttpGet("marcasProduto")]
        public async Task<ActionResult<IReadOnlyList<Produto>>> GetMarcasProduto()
        {
            var marcasProduto = await _repository.GetMarcasProdutoAsync();

            return Ok(marcasProduto);
        }

        [HttpGet("tiposProduto")]
        public async Task<ActionResult<IReadOnlyList<Produto>>> GetTiposProduto()
        {
            var tiposProduto = await _repository.GetTiposProdutoAsync();

            return Ok(tiposProduto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _repository.GetProdutoByIdAsync(id);

            return Ok(produto);
        }
    }
}