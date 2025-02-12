using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class ComponenteDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Nome deve ter no minimo 3 caracteres")]
        public string Nome { get; set; }

        [MinLength(5, ErrorMessage = "Especificação deve conter no mínimo 1 especificação detalhada")]
        public string? Especificacao { get; set; }

        [Required]
        public string Link { get; set; } 

        [Required]
        public double Valor { get; set; }

        [Required]
        public int Unidade { get; set; } = 1;
    }
}
