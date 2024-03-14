using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NetRestaurantAPI.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Menu> Menu { get; set; } 
        public DbSet<Categoria> Categorias { get; set; } 
        public DbSet<Product> Produtos { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            
        }
    }
}
