using devboost.Domain.Model;
using devboost.Domain.MongoDBModel;
using devboost.Domain.Repository;
using devboost.MongoDB.Repository.Context.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.MongoDB.Repository
{
    public class PedidoMGDBRepository : IPedidoMGDBRepository
    {
        readonly IMongoCollection<PedidoMGDB> _pedidos;

        public PedidoMGDBRepository(IMongoDBContext mongoDBContext)
        {
            _pedidos = mongoDBContext.GetDatabase().GetCollection<PedidoMGDB>("pedido");
        }

        public async Task<PedidoMGDB> GetPedidoByPagamento(Guid pagamentoId)
        {
            return await _pedidos.Find(pedido => true).FirstOrDefaultAsync();
        }

        public async Task<List<PedidoMGDB>> GetPedidos(StatusPedido statusPedido)
        {
            return await _pedidos.Find(pedido => pedido.StatusPedido == statusPedido)
                .ToListAsync();
        }

        public async Task<List<PedidoMGDB>> GetPedidos(StatusPedido statusPedido, double distancia, int peso)
        {
            return await _pedidos.Find(pedido => 
                pedido.StatusPedido == statusPedido &&
                pedido.DistanciaParaOrigem == distancia &&
                pedido.Peso <= peso
            )
            .ToListAsync();
        }

        public async Task AddPedido(PedidoMGDB pedido)
        {
            await _pedidos.InsertOneAsync(pedido);
        }

        public async Task UpdatePedido(PedidoMGDB pedido)
        {
            await _pedidos.ReplaceOneAsync(p => p.Id == pedido.Id, pedido);
        }

        public async Task AddPedidoDrone(PedidoDrone pedidoDrone)
        {
            throw new NotImplementedException();
        }
    }
}
