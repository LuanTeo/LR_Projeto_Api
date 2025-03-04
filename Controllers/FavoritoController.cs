using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LR_Projeto_Api.DTO;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("favorito")]
    public class FavoritoController : Controller
    {
        private readonly AppDbContext _context;

        public FavoritoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaFavoritos = await _context.Favoritos
                    .Include(f => f.Usuario)
                    .Include(f => f.Setup)
                    .Select(f => new
                    {
                        f.Id,
                        Usuario = f.Usuario != null ? new { f.Usuario.Id, f.Usuario.Nome } : null,
                        Setup = f.Setup != null ? new { f.Setup.Id, f.Setup.Nome } : null
                    })
                    .ToListAsync();

                return Ok(listaFavoritos);
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
                var favorito = await _context.Favoritos
                    .Include(f => f.Usuario)
                    .Include(f => f.Setup)
                    .Where(f => f.Id == id)
                    .Select(f => new
                    {
                        f.Id,
                        Usuario = f.Usuario != null ? new { f.Usuario.Id, f.Usuario.Nome } : null,
                        Setup = f.Setup != null ? new { f.Setup.Id, f.Setup.Nome } : null
                    })
                    .FirstOrDefaultAsync();

                if (favorito == null)
                {
                    return NotFound($"Favorito #{id} não encontrado");
                }

                return Ok(favorito);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FavoritoDTO item)
        {
            try
            {
                if (!await UsuarioExist(item.UsuarioId))
                {
                    return BadRequest("O Usuário fornecido não existe!");
                }

                if (!await SetupExist(item.SetupId))
                {
                    return BadRequest("O Setup fornecido não existe!");
                }

                var favorito = new Favorito()
                {
                    UsuarioId = item.UsuarioId,
                    SetupId = item.SetupId
                };

                await _context.Favoritos.AddAsync(favorito);
                await _context.SaveChangesAsync();

                return Created("", item);
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
                var favorito = await _context.Favoritos.FindAsync(id);

                if (favorito == null)
                {
                    return NotFound();
                }

                _context.Favoritos.Remove(favorito);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        private async Task<bool> UsuarioExist(int id)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == id);
        }

        private async Task<bool> SetupExist(int id)
        {
            return await _context.Setups.AnyAsync(s => s.Id == id);
        }
    }
}
