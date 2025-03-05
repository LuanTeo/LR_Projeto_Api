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
        [StringLength(11, ErrorMessage = "CPF precisa estar no formato xxxxxxxxxxx")]
        public string Cpf { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; } = "";

        [Required]
        public string Senha { get; set; } = "";

        [Required]
        [StringLength(10, ErrorMessage = "Data precisa estar no formato dd/MM/YYYY")]
        public string Data_Nascimento { get; set; }

        [Required]
        public int CidadeId { get; set; }
    }
}
