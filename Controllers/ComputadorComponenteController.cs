using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("computadorComponente")]
    public class ComputadorComponenteController : Controller
    {
        private readonly AppDbContext _context;

        public ComputadorComponenteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaComponentes = await _context.ComputadoresComponentes.ToListAsync();
                return Ok(listaComponentes);
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
                var componente = await _context.ComputadoresComponentes.FindAsync(id);

                if (componente == null)
                {
                    return NotFound($"Componente #{id} não encontrado");
                }

                return Ok(componente);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComputadorComponenteDTO item)
        {
            try
            {
                var componente = new ComputadorComponente()
                {
                    Quantidade = item.Quantidade,
                    ComputadorID = item.ComputadorID,
                    ComponenteId = item.ComputadorID,     
                };

                await _context.ComputadoresComponentes.AddAsync(componente);
                await _context.SaveChangesAsync();

                return Created("", componente);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ComputadorComponenteDTO item)
        {
            try
            {
                var componente = await _context.ComputadoresComponentes.FindAsync(id);

                if (componente is null)
                {
                    return NotFound();
                }

                componente.Quantidade = item.Quantidade;
                componente.ComputadorID = item.ComputadorID;
                componente.ComponenteId = item.ComponenteId;       

                _context.ComputadoresComponentes.Update(componente);
                await _context.SaveChangesAsync();

                return Ok(componente);
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
                var componente = await _context.ComputadoresComponentes.FindAsync(id);

                if (componente is null)
                {
                    return NotFound();
                }

                _context.ComputadoresComponentes.Remove(componente);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Componente #{id} removido com sucesso" });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
