namespace WebApplication1.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Product> Data { get; set; }
        public Menu Menu { get; set; }
    }
}
