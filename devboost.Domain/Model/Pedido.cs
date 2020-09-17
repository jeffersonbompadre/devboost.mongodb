using devboost.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace devboost.Domain.Model
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public int Peso { get; set; }
        public DateTime DataHora { get; set; }
        public double DistanciaParaOrigem { get; set; }

        [JsonIgnore]
        public StatusPedido StatusPedido { get; set; }

        [NotMapped]
        public string DescricaoStatus => PedidoDescricaoStatus.GetDescricaoStatus(StatusPedido);

        [BsonIgnore]
        [JsonIgnore]
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public Guid PagamentoCartaoId { get; set; }
        public PagamentoCartao PagamentoCartao { get; set; }

        [BsonIgnore]
        public List<PedidoDrone> PedidosDrones { get; set; } = new List<PedidoDrone>();
    }

    public enum StatusPedido
    {
        aguardandoAprovacao = 0,
        reprovado = 1,
        aguardandoEntrega = 2,
        despachado = 3,
        entregue = 4
    }
}
