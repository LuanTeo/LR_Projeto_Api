using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    /*
     `id_end` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `rua_end` VARCHAR(200) NOT NULL,
  `bairro_end` VARCHAR(80) NOT NULL,
  `numero_end` INT,
  `complemento_end` VARCHAR(100),
  `referencia_end` VARCHAR(200),
  `cep_end` INT,
  `id_usu_fk` INT NOT NULL,
   FOREIGN KEY (`id_usu_fk`)
    REFERENCES `Usuario` (`id_usu`)
     */
    [Table("Endereco"),PrimaryKey(nameof(Id))]
    public class Endereco
    {
        [Column(id_end)]
        public int id { get; set; }

        [Column(rua_end)]
        public string endereco {  get; set; }

        [Column(bairro_end)]
        public string Bairro {  get; set; }

    }
}
