using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class ComputadorComponenteDTO
    {
        [Required]
        public int Quantidade { get; set; }

        [Required]
        public int ComputadorID { get; set; }

        [Required]
        public int ComponenteId { get; set; }
    }
}
