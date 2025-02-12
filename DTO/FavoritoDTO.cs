using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class FavoritoDTO
    {
        [Required]
        public int Id_User { get; set; }

        [Required]
        public int Id_Setup { get; set; }
    }
}
