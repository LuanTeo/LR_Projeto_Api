using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class LoginDTO
    {
        [Required]
        [MinLength(5)]
        public required string Username { get; set; }

        [Required]
        [MinLength(5)]
        public required string Password { get; set; }
    }
}
