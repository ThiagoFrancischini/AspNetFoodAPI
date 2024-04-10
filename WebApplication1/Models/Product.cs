using NetRestaurantAPI.Models;

namespace WebApplication1.Models
{
    public class Product
    {
        public Product()
        {
            Ingredients = new List<string>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }   
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public string? Thumbnail { get; set; }
        public List<string> Ingredients { get; set; }
        public Guid? CategoriaId { get; set; }

        public void EntidadeValida()
        {
            if(CategoriaId == Guid.Empty)
            {
                throw new Exception("Informe uma categoria!");
            }

            if (Price == 0)
            {
                throw new Exception("Informe um Preço!");
            }

            if(string.IsNullOrEmpty(Title)) 
            {
                throw new Exception("Informe um Titulo!");
            }
        }        
        public List<PedidoProduto>? PedidoProduto { get; }
    }
}
