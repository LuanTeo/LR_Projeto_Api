using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class SetupDTO
    {
        [Required]
        public int Unidade { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public double Valor { get; set; }

        public string? Descricao { get; set; }
    }
}