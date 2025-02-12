using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class EnderecoDTO
    {
        [Required]
        public string Rua_Lote { get; set; }

        [Required]
        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Referencia { get; set; }

        [Required]
        public int Cep { get; set; }

        [Required]
        public int Id_usu { get; set; }
    }
}
