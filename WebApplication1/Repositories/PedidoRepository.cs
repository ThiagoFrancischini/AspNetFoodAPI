using Microsoft.EntityFrameworkCore;
using NetRestaurantAPI.Models;
using Newtonsoft.Json;

namespace NetRestaurantAPI.Repositories
{
    public class PedidoRepository(Contexto contexto)
    {
        public void InserePedido(Pedido pedido)
        {
            if (pedido.Produtos == null || pedido.Produtos.Count == 0)
            {
                throw new Exception("Informe ao menos um produto");
            }

            pedido.Id = Guid.NewGuid();

            pedido.StatusPedido = Enums.MyEnums.enStatusPedido.EmAnalise;

            pedido.PrecoTotal = 0;

            pedido.Produtos.ForEach(p => pedido.PrecoTotal += p.Price);            

            pedido.EntidadeValida();

            contexto.Pedidos.AddAsync(pedido);

            contexto.SaveChanges();
        }

        public async Task<List<Pedido>> ProcuraPedidosPorUsuario(Guid userId)
        {
            List<Pedido> pedidos = await contexto.Pedidos.Where(p => p.Usuario.Id == userId).ToListAsync();

            return pedidos;
        }

        public async void AlteraStatusPedido(Pedido pedido)
        {
            Pedido pedidoVelho = await contexto.Pedidos.FindAsync(pedido.Id) ?? throw new Exception("Não foi encontrado nenhum pedido com o Id informado");

            pedidoVelho.StatusPedido = pedido.StatusPedido;

            contexto.Pedidos.Update(pedidoVelho);

            contexto.SaveChanges();
        }
    }
}
