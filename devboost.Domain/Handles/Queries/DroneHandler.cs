using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries
{
    public class DroneHandler : IDroneHandler
    {
        readonly IDroneRepository _droneRepository;
        readonly IPedidoRepository _pedidoRepository;

        public DroneHandler(IDroneRepository droneRepository, IPedidoRepository pedidoRepository)
        {
            _droneRepository = droneRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<Drone>> BuscarDrone()
        {
            var result = await _droneRepository.GetAll();
            result.ForEach(drone =>
            {
                drone.PedidosDrones.ForEach(pedidos =>
                {
                    var pedido = _pedidoRepository.GetPedidoById(pedidos.PedidoId).Result;
                    drone.Pedidos.Add(pedido);
                });
            });
            return result;
        }
    }
}
