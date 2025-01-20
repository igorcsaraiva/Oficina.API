using Microsoft.EntityFrameworkCore;
using Oficina.API.Models;
using Oficina.API.Repository;

namespace Oficina.API.Services
{
    public class ClienteService : IService<Cliente>
    {
        public readonly IRepository<Cliente> _clienteRepository;

        public ClienteService(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente Obj)
        {
            return _clienteRepository.Adicionar(Obj);
        }

        public Cliente Atualizar(Cliente Obj)
        {
           return _clienteRepository.Atualizar(Obj);
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            return await _clienteRepository.BuscarPorId(id);
        }

        public void Remover(Cliente Obj)
        {
            _clienteRepository.Remover(Obj);
        }

        public async Task<IEnumerable<Cliente>> BuscarTodos()
        {
            return await _clienteRepository.QueryGenerica()
                .Include(c => c.Veiculos)
                .Include(c => c.Enderecos)
                .ToListAsync();
        }
    }
}
