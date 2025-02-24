using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Computador_Componente"), PrimaryKey(nameof(Id))]
    public class ComputadorComponente
    {
        [Column("id_com_comp")]
        public int Id { get; set; }

        [Column("quantidade_com_comp")]
        public int Quantidade { get; set; }

        [Column("id_com_fk")]
        public int ComputadorID { get; set; }

        [Column("id_comp_fk")]
        public int ComponenteId { get; set; }

        public virtual Computador? Computador { get; set; }

        public virtual Componente? Componente { get; set; }

    }
}
