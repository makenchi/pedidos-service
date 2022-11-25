using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pedidoServiceApi.Data;
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
    }
}
