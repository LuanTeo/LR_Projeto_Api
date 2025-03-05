using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.DTO
{
    public class PerifericoDTO
    {
        [Required]
        public string Nome { get; set; }

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
