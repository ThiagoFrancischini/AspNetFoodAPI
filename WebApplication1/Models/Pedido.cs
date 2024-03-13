using WebApplication1.Models;

namespace NetRestaurantAPI.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataInclusao { get; set; }
        public List<Product> Produtos { get; set; }
        public float PrecoTotal { get; set; }                
    }
}
