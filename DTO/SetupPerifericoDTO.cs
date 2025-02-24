using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class SetupPerifericoDTO
    {
        [Required]
        public int SetupId { get; set; }

        [Required]
        public int PerifericoId { get; set; }
    }
}
