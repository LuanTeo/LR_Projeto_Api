using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class SetupComputadorDTO
    {
        [Required]
        public int SetupId { get; set; }

        [Required]
        public int ComputadorId { get; set; }
    }
}
