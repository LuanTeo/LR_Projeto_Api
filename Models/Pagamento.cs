using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Column("id_pag")]
        public int Id { get; set; }

        [Column("forma_pag")]
        public string FormaPagamento { get; set; } = "";

        [Column("data_pag")]
        public DateTime DataPagamento { get; set; }

        [Column("id_car_fk")]
        public int CarrinhoId { get; set; }

        public virtual Carrinho? Carrinho { get; set; }
    }
}
