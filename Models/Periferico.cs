using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Periferico")]
    public class Periferico
    {
        [Column("id_per")]
        public int Id { get; set; }

        [Column("nome_per")]
        public string Nome { get; set; }

        [Column("valor_per")]
        public double Valor { get; set; }

        [Column("especificacao_per")]
        public string? Especificacao { get; set; }

        [Column("link_per")]
        public string Link { get; set; }

        [Column("unidade_per")]
        public int Unidade { get; set; }

        public ICollection<SetupPeriferico>? SetupPeriferico { get; set; }
    }
}
