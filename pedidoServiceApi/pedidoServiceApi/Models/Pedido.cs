namespace pedidoServiceApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public long NumeroDoPedido { get; set; }
        public int idClinte { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
    }
}
