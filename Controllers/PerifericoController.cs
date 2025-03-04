using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LR_Projeto_Api.DTO;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("periferico")]
    public class PerifericoController : Controller
    {
        private readonly AppDbContext _context;

        public PerifericoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPerifericos = await _context.Perifericos.ToListAsync();
                return Ok(listaPerifericos);
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
                var periferico = await _context.Perifericos.FindAsync(id);

                if (periferico == null)
                {
                    return NotFound($"Periférico #{id} não encontrado");
                }

                return Ok(periferico);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PerifericoDTO item)
        {
            try
            {
                var periferico = new Periferico()
                {
                    Valor = item.Valor,
                    Especificacao = item.Especificacao,
                    Link = item.Link,
                    Unidade = item.Unidade
                };
                await _context.Perifericos.AddAsync(periferico);
                await _context.SaveChangesAsync();

                return Created("", periferico);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PerifericoDTO item)
        {
            try
            {
                var periferico = await _context.Perifericos.FindAsync(id);

                if (periferico is null)
                {
                    return NotFound();
                }

                periferico.Valor = item.Valor;
                periferico.Especificacao = item.Especificacao;
                periferico.Link = item.Link;
                periferico.Unidade = item.Unidade;

                _context.Perifericos.Update(periferico);
                await _context.SaveChangesAsync();

                return Ok(periferico);
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
                var periferico = await _context.Perifericos.FindAsync(id);

                if (periferico == null)
                {
                    return NotFound();
                }

                _context.Perifericos.Remove(periferico);
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