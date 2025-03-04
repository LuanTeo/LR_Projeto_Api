using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("setupComputador")]
    public class SetupComputadorController : Controller
    {
        private readonly AppDbContext _context;

        public SetupComputadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaSetups = await _context.SetupsComputadores.ToListAsync();
                return Ok(listaSetups);
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
                var setup = await _context.SetupsComputadores.FindAsync(id);

                if (setup == null)
                {
                    return NotFound($"Setup de Computador #{id} não encontrado");
                }

                return Ok(setup);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetupComputadorDTO item)
        {
            try
            {
                var setup = new SetupComputador()
                {
                    SetupId = item.SetupId,
                    ComputadorId = item.ComputadorId,
                };

                await _context.SetupsComputadores.AddAsync(setup);
                await _context.SaveChangesAsync();

                return Created("", setup);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SetupComputadorDTO item)
        {
            try
            {
                var setup = await _context.SetupsComputadores.FindAsync(id);

                if (setup is null)
                {
                    return NotFound();
                }

                setup.SetupId = item.SetupId;
                setup.ComputadorId = item.ComputadorId;
        
                _context.SetupsComputadores.Update(setup);
                await _context.SaveChangesAsync();

                return Ok(setup);
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
                var setup = await _context.SetupsComputadores.FindAsync(id);

                if (setup is null)
                {
                    return NotFound();
                }

                _context.SetupsComputadores.Remove(setup);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Setup de Computador #{id} removido com sucesso" });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
