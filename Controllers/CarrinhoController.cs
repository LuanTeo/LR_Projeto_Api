using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.Models;
using LR_Projeto_Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("carrinho")]
    public class CarrinhoController : Controller
    {
        private readonly AppDbContext _context;

        public CarrinhoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaCarrinhos = await _context.Carrinho
                    .Include(c => c.Usuario)
                    .Include(c => c.Setup)
                    .Select(c => new
                    {
                        c.Id,
                        c.Valor,
                        Usuario = c.Usuario != null ? new { c.Usuario.Id, c.Usuario.Nome } : null,
                        Setup = c.Setup != null ? new { c.Setup.Id, c.Setup.Nome } : null
                    })
                    .ToListAsync();

                return Ok(listaCarrinhos);
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
                var carrinho = await _context.Carrinho
                    .Include(c => c.Usuario)
                    .Include(c => c.Setup)
                    .Where(c => c.Id == id)
                    .Select(c => new
                    {
                        c.Id,
                        c.Valor,
                        Usuario = c.Usuario != null ? new { c.Usuario.Id, c.Usuario.Nome } : null,
                        Setup = c.Setup != null ? new { c.Setup.Id, c.Setup.Nome } : null
                    })
                    .FirstOrDefaultAsync();

                if (carrinho == null)
                {
                    return NotFound($"Carrinho #{id} não encontrado");
                }

                return Ok(carrinho);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarrinhoDTO item)
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

                var carrinho = new Carrinho()
                {
                    Valor = item.Valor,
                    UsuarioId = item.UsuarioId,
                    SetupId = item.SetupId
                };
                await _context.Carrinho.AddAsync(carrinho);
                await _context.SaveChangesAsync();

                return Created("", carrinho);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarrinhoDTO item)
        {
            try
            {
                var carrinho = await _context.Carrinho.FindAsync(id);

                if (carrinho == null)
                {
                    return NotFound();
                }

                carrinho.Valor = item.Valor;
                carrinho.UsuarioId = item.UsuarioId;
                carrinho.SetupId = item.SetupId;

                _context.Carrinho.Update(carrinho);
                await _context.SaveChangesAsync();

                return Ok(carrinho);
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
                var carrinho = await _context.Carrinho.FindAsync(id);

                if (carrinho == null)
                {
                    return NotFound();
                }

                _context.Carrinho.Remove(carrinho);
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