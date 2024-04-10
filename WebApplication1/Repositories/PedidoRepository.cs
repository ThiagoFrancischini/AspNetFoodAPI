﻿using Microsoft.EntityFrameworkCore;
using NetRestaurantAPI.Models;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace NetRestaurantAPI.Repositories
{
    public class PedidoRepository(Contexto contexto)
    {
        public void InserePedido(Pedido pedido)
        {
            try
            {
                contexto.Database.BeginTransaction();

                if (pedido.Produtos == null || pedido.Produtos.Count == 0)
                {
                    throw new Exception("Informe ao menos um produto");
                }

                pedido.Id = Guid.NewGuid();

                pedido.StatusPedido = Enums.MyEnums.enStatusPedido.EmAnalise;

                pedido.PrecoTotal = 0;

                pedido.Produtos.ForEach(p => pedido.PrecoTotal += p.Price);

                pedido.EntidadeValida();

                string sqlInsercaoPedido = " INSERT INTO Pedidos (Id, UsuarioId, DataInclusao, PrecoTotal, StatusPedido) VALUES (@p0, @p1, @p2, @p3, @p4) ";

                var parametrosPedido = new object[] { pedido.Id.ToString().ToUpper(), pedido.Usuario.Id.ToString(), pedido.DataInclusao, pedido.PrecoTotal, Convert.ToInt32(pedido.StatusPedido) };

                contexto.Database.ExecuteSqlRaw(sqlInsercaoPedido, parametrosPedido);

                foreach (Product produto in pedido.Produtos)
                {
                    string sqlInsercaoRelacao = " INSERT INTO PedidoProduto (Id, PedidoId, ProdutoId) VALUES (@p0, @p1, @p2) ";

                    var parametrosRelacao = new object[] {Guid.NewGuid().ToString(), pedido.Id.ToString().ToUpper(), produto.Id.ToString().ToUpper() };

                    contexto.Database.ExecuteSqlRaw(sqlInsercaoRelacao, parametrosRelacao);
                }

                contexto.Database.CommitTransaction();                
            }
            catch 
            {
                contexto.Database.RollbackTransaction();

                throw;
            }            
        }

        public async Task<List<Pedido>> ProcuraPedidosPorUsuario(Guid userId)
        {
            List<Pedido> pedidos = await contexto.Pedidos.Where(p => p.Usuario.Id.ToString().ToUpper() == userId.ToString().ToUpper()).ToListAsync();

            if(pedidos != null && pedidos.Count > 0)
            {
                foreach(var pedido in pedidos) 
                {
                    var produtos = contexto.Produtos.FromSqlRaw(" SELECT Produtos.Id, Produtos.CategoriaId, Produtos.Cover, Produtos.Description, Produtos.Ingredients, Produtos.Price, Produtos.Thumbnail, Produtos.Title, PedidoProduto.Id, PedidoProduto.PedidoId, PedidoProduto.ProdutoId " +
                                                                " FROM Produtos " +
                                                                " INNER JOIN PedidoProduto on PedidoProduto.ProdutoId = Produtos.Id  " +
                                                                " WHERE UPPER(PedidoProduto.PedidoId)  = @p0 ", new object[] { pedido.Id.ToString().ToUpper() });

                    pedido.Produtos = produtos.ToList();
                }                
            }
            

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
