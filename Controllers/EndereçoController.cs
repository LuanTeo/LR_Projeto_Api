using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : Controller
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaEnderecos = await _context.Enderecos.ToListAsync();
                return Ok(listaEnderecos);
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
                var endereco = await _context.Enderecos.FindAsync(id);

                if (endereco == null)
                {
                    return NotFound($"Endereço #{id} não encontrado");
                }

                return Ok(endereco);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnderecoDTO item)
        {
            try
            {
                var endereco = new Endereco()
                {
                    Rua_Lote = item.Rua_Lote,
                    Numero = item.Numero,
                    Bairro = item.Bairro,
                    Complemento = item.Complemento,
                    Referencia = item.Referencia,
                    Cep = item.Cep,
                    Id_usu = item.Id_usu,
                };

                await _context.Enderecos.AddAsync(endereco);
                await _context.SaveChangesAsync();

                return Created("", endereco);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EnderecoDTO item)
        {
            try
            {
                var endereco = await _context.Enderecos.FindAsync(id);

                if (endereco is null)
                {
                    return NotFound();
                }

                endereco.Rua_Lote = item.Rua_Lote;
                endereco.Bairro = item.Bairro;
                endereco.Numero = item.Numero;
                endereco.Complemento = item.Complemento;
                endereco.Referencia = item.Referencia;
                endereco.Cep = item.Cep;
                endereco.Id_usu = item.Id_usu;

                _context.Enderecos.Update(endereco);
                await _context.SaveChangesAsync();

                return Ok(endereco);
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
                var endereco = await _context.Enderecos.FindAsync(id);

                if (endereco is null)
                {
                    return NotFound();
                }

                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Endereço #{id} removido com sucesso" });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
