namespace WebApplication1.Models
{
    public class Menu
    {
        public Menu()
        {
            Categorias = new List<Categoria>();
        }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
