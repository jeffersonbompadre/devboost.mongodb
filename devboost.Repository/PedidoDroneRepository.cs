using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class PedidoDroneRepository : IPedidoDroneRepository
    {
        readonly DataContext _dataContext;

        public PedidoDroneRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPedidoDrone(PedidoDrone pedidoDrone)
        {
            _dataContext.PedidoDrone.Add(pedidoDrone);
            await _dataContext.SaveChangesAsync();
        }
    }
}
