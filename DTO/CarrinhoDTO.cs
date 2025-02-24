using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.DTO
{
    public class CarrinhoDTO
    {
        [Required]
        public double Valor { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int SetupId { get; set; }
    }
}
