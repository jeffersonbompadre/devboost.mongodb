using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.MongoDB.Repository.Context.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.MongoDB.Repository
{
    public class PedidoMGDBRepository : IPedidoRepository
    {
        readonly IMongoCollection<Pedido> _pedidos;

        public PedidoMGDBRepository(IMongoDBContext mongoDBContext)
        {
            _pedidos = mongoDBContext.GetDatabase().GetCollection<Pedido>("pedido");
        }

        public async Task<Pedido> GetPedidoByPagamento(Guid pagamentoId)
        {
            return await _pedidos.Find(pedido => pedido.PagamentoCartao.Id == pagamentoId).FirstOrDefaultAsync();
        }

        public async Task<Pedido> GetPedidoById(Guid pedidoId)
        {
            return await _pedidos.Find(pedido => pedido.Id == pedidoId).FirstOrDefaultAsync();
        }

        public async Task<List<Pedido>> GetPedidos(StatusPedido statusPedido)
        {
            return await _pedidos.Find(pedido => pedido.StatusPedido == statusPedido)
                .ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidos(StatusPedido statusPedido, double distancia, int peso)
        {
            return await _pedidos
                .Find(pedido => pedido.StatusPedido == statusPedido && pedido.DistanciaParaOrigem <= distancia && pedido.Peso <= peso)
                .ToListAsync();
        }

        public async Task AddPedido(Pedido pedido)
        {
            await _pedidos.InsertOneAsync(pedido);
        }

        public async Task UpdatePedido(Pedido pedido)
        {
            await _pedidos.ReplaceOneAsync(p => p.Id == pedido.Id, pedido);
        }
    }
}
