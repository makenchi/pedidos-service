using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pedidoServiceApi.Data;
using pedidoServiceApi.DTO;
using pedidoServiceApi.Models;

namespace pedidoServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Pedido>>> Get() 
        {
            return Ok(await _context.Pedidos.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult> Add(AddPedidoDTO pedido)
        {
            if (pedido.ItensDoPedido == null || pedido.ItensDoPedido.Count < 1)
            {
                return BadRequest("Pedido precisa ao menos ter um item.");
            }

            return Ok("Pedido inserido com sucesso.");
        }
    }
}
