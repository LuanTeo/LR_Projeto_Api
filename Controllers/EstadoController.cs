using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("estado")]
    public class EstadoController : Controller
    {
        private readonly AppDbContext _context;

        public EstadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaEstados = await _context.Estados.ToListAsync();

                return Ok(listaEstados);
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
                var estado = await _context.Estados.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (estado == null)
                {
                    return NotFound($"Estado #{id} não encontrado");
                }

                return Ok(estado);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstadoDTO item)
        {
            try
            {

                var estados = new Estado()
                {
                    Nome = item.Nome,
                    Uf = item.Uf
                };

                await _context.Estados.AddAsync(estados);
                await _context.SaveChangesAsync();

                return Created("", estados);
            }
            catch (Exception e)
            {
                return Problem();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadoDTO item)
        {
            try
            {
                var estado = await _context.Estados.FindAsync(id);

                if (estado is null)
                {
                    return NotFound();
                }

                estado.Nome = item.Nome;
                estado.Uf = item.Uf;

                _context.Estados.Update(estado);
                await _context.SaveChangesAsync();

                return Ok(estado);
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
                var estado = await _context.Estados.FindAsync(id);

                if (estado is null)
                {
                    return NotFound();
                }

                _context.Estados.Remove(estado);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
