namespace WebApplication1.Models
{
    public class Menu
    {
        public Menu()
        {
            Sections = new List<Section>();
        }
        public List<Section> Sections { get; set; }
    }
}
