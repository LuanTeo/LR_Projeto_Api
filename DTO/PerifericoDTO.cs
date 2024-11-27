using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class PerifericoDTO
    {
        [Required]
        public double Valor { get; set; }

        public string? Especificacao { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }

        [Required]
        public int Unidade { get; set; }
    }
}
