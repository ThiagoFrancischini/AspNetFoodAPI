using WebApplication1.Models;

namespace NetRestaurantAPI.Models
{
    public class PedidoProduto
    {
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public Guid ProdutoId { get; set; }
        public Product Produto { get; set; }
    }
}
