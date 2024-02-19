using Microsoft.EntityFrameworkCore;
using NetRestaurantAPI.Models;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace NetRestaurantAPI.Repositories
{    
    public class CategoriaRepository(Contexto contexto)
    {        
        public async void InsereCategoria(Categoria categoria)
        {                        
            //Em teoria como essa é uma API de apoio eu não queria perder tanto tempo nela, então fiz um fluxo que em teoria só deixe o usuário criar um Menu

            var menuRepository = new MenuRepository(contexto);

            Menu menu = menuRepository.ProcuraMenu().Result[0];

            categoria.Id = Guid.NewGuid();

            menu.Categorias.Add(categoria);                        

            contexto.Menu.Update(menu);

            await contexto.SaveChangesAsync();
        }
    }
}
