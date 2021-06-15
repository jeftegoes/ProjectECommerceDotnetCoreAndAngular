using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }

        public int IdTipoProduto { get; set; }
        [ForeignKey("IdTipoProduto")]
        public TipoProduto TipoProduto { get; set; }

        public int IdMarcaProduto { get; set; }
        [ForeignKey("IdMarcaProduto")]
        public MarcaProduto MarcaProduto { get; set; }

    }
}