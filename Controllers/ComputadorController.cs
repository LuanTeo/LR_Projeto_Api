using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("computador")]
    public class ComputadorController : Controller
    {
        private readonly AppDbContext _context;

        public ComputadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaComputadores = await _context.Computadores.ToListAsync();
                return Ok(listaComputadores);
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
                var computador = await _context.Computadores.FindAsync(id);

                if (computador == null)
                {
                    return NotFound($"Computador #{id} não encontrado");
                }

                return Ok(computador);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComputadorDTO item)
        {
            try
            {
                var computador = new Computador()
                {
                    Nome = item.Nome,
                    Unidade = item.Unidade,
                    Link = item.Link,
                    Valor = item.Valor
                };

                await _context.Computadores.AddAsync(computador);
                await _context.SaveChangesAsync();

                return Created("", computador);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ComputadorDTO item)
        {
            try
            {
                var computador = await _context.Computadores.FindAsync(id);

                if (computador is null)
                {
                    return NotFound();
                }

                computador.Nome = item.Nome;
                computador.Unidade = item.Unidade;
                computador.Link = item.Link;
                computador.Valor = item.Valor;

                _context.Computadores.Update(computador);
                await _context.SaveChangesAsync();

                return Ok(computador);
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
                var computador = await _context.Computadores.FindAsync(id);

                if (computador is null)
                {
                    return NotFound();
                }

                _context.Computadores.Remove(computador);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Computador #{id} removido com sucesso" });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}




