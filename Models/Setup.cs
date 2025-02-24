using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Setup")]
    public class Setup
    {
        [Column("id_set")]
        public int Id {  get; set; }

        [Column("unidade_set")]
        public int Unidade { get; set; }

        [Column("nome_set")]
        public string Nome { get; set; }

        [Column("valor_set")]
        public double Valor { get; set; }

        [Column("descricao_set")]
        public string? Descricao { get; set; }

        public ICollection<Favorito>? Favoritos { get; set; }

        public ICollection<Carrinho>? Carrinho { get; set; }

        public ICollection<SetupComputador>? SetupComputador { get; set; }

        public ICollection<SetupPeriferico>? SetupPeriferico { get; set; }
    }
}