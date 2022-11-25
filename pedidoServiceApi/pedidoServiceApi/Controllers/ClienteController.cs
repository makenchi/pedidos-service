using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pedidoServiceApi.Data;
using pedidoServiceApi.Models;

namespace pedidoServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente adicionado com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient(Cliente cliente)
        {
            var dbClient = await _context.Clientes.FindAsync(cliente.Id);
            if (dbClient == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            dbClient.Nome = cliente.Nome;
            dbClient.Email = cliente.Email;

            await _context.SaveChangesAsync();

            return Ok("Informações do cliente alteradas com sucesso.");
        }

        [HttpDelete("{id")]
        public async Task<ActionResult> Delete(int id)
        {
            var dbClient = await _context.Clientes.FindAsync(id);
            if (dbClient == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            _context.Clientes.Remove(dbClient);
            await _context.SaveChangesAsync();

            return Ok("Cliente excluído com sucesso.");
        }
    }
}
