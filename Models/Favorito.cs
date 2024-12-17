using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Favorito"), PrimaryKey(nameof(Id))]
    public class Favorito
    {
        [Column("id_fav")]
        public int Id { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public virtual Setup? Setup { get; set; }

    }
}
