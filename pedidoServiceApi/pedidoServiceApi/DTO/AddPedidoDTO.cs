using pedidoServiceApi.Models;

namespace pedidoServiceApi.DTO
{
    public class AddPedidoDTO
    {
        public int IdCliente { get; set; }
        public long NumeroDoPedido { get; set; }
        public List<ItemPedido> ItensDoPedido { get; set; }
    }
}
