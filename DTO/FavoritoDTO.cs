﻿using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.DTO
{
    public class FavoritoDTO
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int SetupId { get; set; }
    }
}
