﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_Projeto_Api.Models
{
    [Table("Favorito"), PrimaryKey(nameof(Id))]
    public class Favorito
    {
        [Column("id_fav")]
        public int Id { get; set; }

        [Column("id_usu_fk")]
        public int UsuarioId { get; set; }

        [Column("id_set_fk")]
        public int SetupId { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public virtual Setup? Setup { get; set; }

    }
}
