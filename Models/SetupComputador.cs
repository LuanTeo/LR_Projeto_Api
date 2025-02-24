using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Setup_Computador")]
    public class SetupComputador
    {
        [Column("id_set_com")]
        public int Id { get; set; }

        [Column("id_set_fk")]
        public int SetupId { get; set; }

        [Column("id_com_fk")]
        public int ComputadorId { get; set; }

        public virtual Setup? Setup { get; set; }

        public virtual Computador? Computador { get; set; }
    }
}
