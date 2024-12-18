using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("id_usu")]
        public int Id { get; set; }

        [Column("nome_usu")]
        public string Nome { get; set; }

        [Column("genero_usu")]
        public int Genero {  get; set; }

        [Column("email_usu")]
        public string Email { get; set; }

        [Column("cpf_usu")]
        public int Cpf { get; set; }

        [Column("telefone_usu")]
        public string Telefone {  get; set; }

        [Column("senha_usu")]
        public string Senha { get; set; }

        [Column("datanasc_usu")]
        public DateTime Data_Nascimento { get; set; }

        [Column("id_cid_fk")]
        public int CidadeId { get; set; }

        // Propriedade de navegação
        public virtual Cidade? Cidade { get; set; }


    }
}
