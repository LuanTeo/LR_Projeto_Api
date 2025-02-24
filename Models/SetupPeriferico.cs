using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Setup_Periferico"), PrimaryKey(nameof(Id))]
    public class SetupPeriferico
    {
        [Column("id_set_per")]
        public int Id { get; set; }

        [Column("id_set_fk")]
        public int SetupId { get; set; }

        [Column("id_per_fk")]
        public int PerifericoId { get; set; }

        public virtual Setup? Setup { get; set; }

        public virtual Periferico? Periferico { get; set; }
    }
}
