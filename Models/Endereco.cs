using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
 
    [Table("Endereco"),PrimaryKey(nameof(Id))]
    public class Endereco
    {
        [Column("id_end")]
        public int Id { get; set; }

        [Column("rua_end")]
        public string Rua_Lote {  get; set; }

        [Column("bairro_end")]
        public string Bairro {  get; set; }

        [Column("numero_end")]
        public string? Numero { get; set; }

        [Column("complemento_end")]
        public string? Complemento { get; set; }

        [Column("referencia_end")]
        public string Referencia { get; set; }

        [Column("cep_end")]
        public int Cep { get; set; }

        [Column("id_usu_fk")]
        public int Id_usu { get; set; }

        public virtual Usuario? Usuario { get; set; }
        
    }
}
