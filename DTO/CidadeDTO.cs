using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class CidadeDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Nome deve ter no minimo 3 caracteres")]
        public string Nome { get; set; } = "";

        [Required]
        public int EstadoId { get; set; }

    }
}
