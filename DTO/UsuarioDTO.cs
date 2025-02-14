using LR_Projeto_Api.Validation;
using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class UsuarioDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome nessecita de no minimo 5 caracteres")]
        public string Nome { get; set; } = "";

        [Required]
        [Range(1,2, ErrorMessage = "genero aceita apenas: 1 - MASCULINO; 2 - FEMININO")]
        public int Genero { get; set; } = 1;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(14, ErrorMessage = "CPF nessecita estar no formato xxx.xxx.xxx-xx")]
        [CustomValidation(typeof(CustomValidator), nameof(CustomValidator.IsEven))]
        public int Cpf { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; } = "";

        [Required]
        public string Senha { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Data nessecita estar no formato YYYY-MM-DD.")]
        public DateTime Data_Nascimento { get; set; }

        [Required]
        public int CidadeId { get; set; }
    }
}
