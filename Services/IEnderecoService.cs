using Oficina.API.Models;

namespace Oficina.API.Services
{
    public interface IEnderecoService : IService<Endereco>
    {
        public Task<IEnumerable<Endereco>> BuscarEnderecosCliente(int id);
    }
}
