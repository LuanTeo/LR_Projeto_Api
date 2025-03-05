using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using System.Security.Cryptography;
using System.Globalization;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context) {

            _context = context;
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

                DateTime dataConvertida = DateTime.ParseExact(item.Data_Nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var usuario = new Usuario {
                    Nome = item.Nome,
                    Email = item.Email,
                    Senha = item.Senha,
                    Genero = item.Genero,
                    Telefone = item.Telefone,
                    Data_Nascimento = dataConvertida,
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDTO item)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario is null)
                {
                    return NotFound();
                }
                DateTime dataConvertida = DateTime.ParseExact(item.Data_Nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                usuario.Nome = item.Nome;
                usuario.Email = item.Email;
                usuario.Senha = item.Senha;
                usuario.Genero = item.Genero;
                usuario.Telefone = item.Telefone;
                usuario.Data_Nascimento = dataConvertida;
                usuario.Cpf = item.Cpf;
                usuario.CidadeId = item.CidadeId;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario is null)
                {
                    return NotFound();
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        private async Task<bool> CityExists(int id){
            return await _context.Cidades.AnyAsync(e => e.Id == id);
        }
    }
}
