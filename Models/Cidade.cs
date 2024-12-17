using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Cidade"), PrimaryKey(nameof(Id))]
    public class Cidade
    {
        [Column("id_cid")]
        public int Id { get; set; }

        [Column("nome_cid")]
        public string Nome { get; set; }

        [Column("id_est_fk")]
        public int EstadoId { get; set; }

        public virtual Estado? Estado { get; set; }
    }
}
