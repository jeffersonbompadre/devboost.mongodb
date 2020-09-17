using devboost.Domain.Entities;
using devboost.Domain.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace devboost.Domain.MongoDBModel
{
    public class PedidoMGDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Peso { get; set; }
        public DateTime DataHora { get; set; }
        public double DistanciaParaOrigem { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public string DescricaoStatus => PedidoDescricaoStatus.GetDescricaoStatus(StatusPedido);

        public Cliente Cliente { get; set; }
        public PagamentoCartao PagamentoCartao { get; set; }
    }
}
