using devboost.Domain.Model;
using devboost.Domain.MongoDBModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IPedidoMGDBRepository
    {
        Task<PedidoMGDB> GetPedidoByPagamento(Guid pagamentoId);
        Task<List<PedidoMGDB>> GetPedidos(StatusPedido statusPedido);
        Task<List<PedidoMGDB>> GetPedidos(StatusPedido statusPedido, double distancia, int peso);
        Task AddPedido(PedidoMGDB pedido);
        Task UpdatePedido(PedidoMGDB pedido);
        Task AddPedidoDrone(PedidoDrone pedidoDrone);
    }
}
