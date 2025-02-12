using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    public class Computador
    {
        [Column("id_com")]
        public int id { get; set; }

        [Column("unidade_com")]
        public int Unidade_Com { get; set; }

        [Column("nome_com")]
        public string Nome_Com { get; set; }

        [Column("link_com")]
        public string link_Com { get; set; }

        [Column("valor_com")]
        public double Valor_com { get; set; }
    }
}
