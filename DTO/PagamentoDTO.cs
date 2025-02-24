using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.DTO
{
    public class PagamentoDTO
    {
        [Required]
        public string FormaPagamento { get; set; } = "";

        [Required]
        public DateTime DataPagamento { get; set; }

        [Required]
        public int CarrinhoId { get; set; }
    }
}
