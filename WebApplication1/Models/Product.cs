namespace WebApplication1.Models
{
    public class Product
    {
        public Product()
        {
            Ingredients = new List<string>();
        }
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public double? Price { get; set; }   
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public string? Thumbnail { get; set; }
        public List<string> Ingredients { get; set; }
        public Categoria Categoria { get; set; }
    }
}
