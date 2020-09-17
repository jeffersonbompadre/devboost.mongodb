using devboost.Domain.Model;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IPedidoDroneRepository
    {
        Task AddPedidoDrone(PedidoDrone pedidoDrone);
    }
}
