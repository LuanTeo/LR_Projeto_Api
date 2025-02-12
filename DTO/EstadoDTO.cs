using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class EstadoDTO
    {
        [Required]
        public string Nome { get; set; }

        [MaxLength(3, ErrorMessage = "Utilize a Sigla do Estado! exemplo 'Rondônia -> RO'")]
        public string Uf { get; set; }
    }
}
