using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Componente"), PrimaryKey(nameof(Id))]
    public class Componente
    {
        [Column("id_comp")]
        public int Id { get; set; }

        [Column("nome_comp")]
        public string Nome { get; set; } = "";

        [Column("especificacao_comp")]
        public string? Especificacao { get; set; }

        [Column("link_comp")]
        public string Link  { get; set; } = "";

        [Column("valor_comp")]
        public double Valor { get; set; }

        [Column("unidade_comp")]
        public int Unidade  { get; set; }

        public ICollection<ComputadorComponente>? ComputadorComponente { get; set; }
    }
}
