using devboost.Domain.Model;

namespace devboost.Domain.Entities
{
    public static class PedidoDescricaoStatus
    {
        public static string GetDescricaoStatus(StatusPedido statusPedido)
        {
            switch (statusPedido)
            {
                case StatusPedido.aguardandoAprovacao:
                    return "Aguardando Aprovação";
                case StatusPedido.reprovado:
                    return "Reprovado";
                case StatusPedido.aguardandoEntrega:
                    return "Aguardando Entrega";
                case StatusPedido.despachado:
                    return "Despachado";
                case StatusPedido.entregue:
                    return "Entregue";
                default:
                    return string.Empty;
            }
        }
    }
}
