using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    public class Pagamento
    {
        [Column("id_pag")]
        public int Id { get; set; }

        [Column("forma_pag")]
        public string Forma_Pag { get; set; }

        [Column("data_pag")]
        public DateTime Data_Pag { get; set; }


    }
}
