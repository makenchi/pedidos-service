namespace pedidoServiceApi.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float ValorUnitario { get; set; }
        public int idPedido { get; set; }
    }
}
