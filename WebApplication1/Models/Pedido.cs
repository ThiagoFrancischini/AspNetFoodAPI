using NetRestaurantAPI.Enums;
using WebApplication1.Models;

namespace NetRestaurantAPI.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataInclusao { get; set; }
        public List<Product> Produtos { get; set; }
        public List<PedidoProduto>? PedidoProduto { get; }
        public double PrecoTotal { get; set; }   
        public MyEnums.enStatusPedido? StatusPedido { get; set; }
        public void EntidadeValida()
        {
            if(this.Id == Guid.Empty)
            {
                throw new Exception("Informe um Id");
            }

            if (this.Usuario == null || this.Usuario.Id == Guid.Empty)
            {
                throw new Exception("Informe um Usuario");
            }

            if (this.DataInclusao < new DateTime(1753,1,1))
            {
                throw new Exception("Informe uma data válida");
            }

            if(this.PrecoTotal <= 0)
            {
                throw new Exception("Preço inválido");
            }

            if (this.StatusPedido == null)
            {
                throw new Exception("Informe um status de pedido");
            }
        }
    }
}
