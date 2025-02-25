using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("cidade")]
    public class CidadeController : Controller
    {
        private readonly AppDbContext _context;

        public CidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaCidades = await _context.Cidades
                    .Include(e => e.Estado)
                    .Select(e => new {
                        e.Id,
                        e.Nome,
                        Estado = new { e.Estado.Id, e.Estado.Nome, e.Estado.Uf }
                    })
                    .ToListAsync();

                return Ok(listaCidades);
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
                var cidade = await _context.Cidades.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (cidade == null)
                {
                    return NotFound($"Cidade #{id} não encontrado");
                }

                return Ok(cidade);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CidadeDTO item)
        {
            try
            {
                if (!await EstadoExist(item.EstadoId))
                {
                    return BadRequest("O Estado fornecida não existe!");
                }

                var cidade = new Cidade()
                {
                    Nome = item.Nome,
                    EstadoId = item.EstadoId
                };

                await _context.Cidades.AddAsync(cidade);
                await _context.SaveChangesAsync();

                return Created("", cidade);
            }
            catch (Exception e)
            {
                return Problem();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CidadeDTO item)
        {
            try
            {
                var cidade = await _context.Cidades.FindAsync(id);

                if (cidade is null)
                {
                    return NotFound();
                }

                cidade.Nome = item.Nome;
                cidade.EstadoId = item.EstadoId;

                _context.Cidades.Update(cidade);
                await _context.SaveChangesAsync();

                return Ok(cidade);
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
                var cidade = await _context.Cidades.FindAsync(id);

                if (cidade is null)
                {
                    return NotFound();
                }

                _context.Cidades.Remove(cidade);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            

        }
        private async Task<bool> EstadoExist(int Id)
        {
            return await _context.Estados.AnyAsync(c => c.Id == Id);
        }
    }
}
