using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("setupsPerifericos")]
    public class SetupPerifericosController : Controller
    {
        private readonly AppDbContext _context;

        public SetupPerifericosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPerifericos = await _context.SetupsPerifericos.ToListAsync();
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
                var periferico = await _context.SetupsPerifericos.FindAsync(id);

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
        public async Task<IActionResult> Post([FromBody] SetupPerifericoDTO item)
        {
            try
            {
                var periferico = new SetupPeriferico()
                {
                    SetupId = item.SetupId,
                    PerifericoId = item.PerifericoId,
                   
                };

                await _context.SetupsPerifericos.AddAsync(periferico);
                await _context.SaveChangesAsync();

                return Created("", periferico);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SetupPerifericoDTO item)
        {
            try
            {
                var periferico = await _context.SetupsPerifericos.FindAsync(id);

                if (periferico is null)
                {
                    return NotFound();
                }

                periferico.SetupId = item.SetupId;
                periferico.PerifericoId = item.PerifericoId;     

                _context.SetupsPerifericos.Update(periferico);
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
                var periferico = await _context.SetupsPerifericos.FindAsync(id);

                if (periferico is null)
                {
                    return NotFound();
                }

                _context.SetupsPerifericos.Remove(periferico);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Periférico #{id} removido com sucesso" });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
