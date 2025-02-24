using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.DTO
{
    public class ComputadorDTO
    {
        [Required]
        public int Unidade { get; set; }

        [Required]
        public string Nome { get; set; } = "";

        [Required]
        public string Link { get; set; } = "";

        [Required]
        public double Valor { get; set; }
    }
}
