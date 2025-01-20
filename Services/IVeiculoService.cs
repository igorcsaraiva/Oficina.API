using Oficina.API.Models;

namespace Oficina.API.Services
{
    public interface IVeiculoService : IService<Veiculo>
    {
        public Task<IEnumerable<Veiculo>> BuscarVeiculosCliente(int id);
    }
}
