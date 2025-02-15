﻿using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using System.Security.Cryptography;

{
    
}

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) {

            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listUsuarios = await _context.Usuarios.ToListAsync();

                return Ok(listUsuarios);

            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();

                if (usuario == null) return NotFound();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO item){
            try
            {
                if (!await CityExists(item.CidadeId))
                {
                    return BadRequest("A Cidade fornecida não existe!");
                }

                var usuario = new Usuario {
                    Nome = item.Nome,
                    Email = item.Email,
                    Senha = item.Senha,
                    Genero = item.Genero,
                    Telefone = item.Telefone,
                    Data_Nascimento = item.Data_Nascimento,
                    Cpf = item.Cpf,
                    CidadeId = item.CidadeId
                };

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Created("", usuario);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPut("{}")]

        private async Task<bool> CityExists(int id){
            return await _context.Cidades.AnyAsync(e => e.Id == id);
        }
    }
}
