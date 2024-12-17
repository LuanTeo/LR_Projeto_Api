using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Estado"), PrimaryKey(nameof(Id))]
    public class Estado
    {
        [Column("id_est")]
        public int Id { get; set; }

        [Column("nome_est")]
        public string Nome { get; set; }

        [Column("uf_est")]
        public string? Uf {  get; set; }

        public ICollection<Cidade>? Cidades { get; set; }
    }
}
