using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Computador"), PrimaryKey(nameof(Id))]
    public class Computador
    {
        [Column("id_com")]
        public int Id { get; set; }

        [Column("unidade_com")]
        public int Unidade { get; set; }

        [Column("nome_com")]
        public string Nome { get; set; } = "";

        [Column("link_com")]
        public string Link { get; set; } = "";

        [Column("valor_com")]
        public double Valor { get; set; }

        public ICollection<SetupComputador>? SetupComputador { get; set; }

        public ICollection<ComputadorComponente>? ComputadorComponente { get; set; }
    }
}
