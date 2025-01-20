
using Microsoft.EntityFrameworkCore;
using Oficina.API.Models;
using Oficina.API.Repository;

namespace Oficina.API.Services
{
    public class EnderecoService : IEnderecoService
    {
        public readonly IRepository<Endereco> _enderecoRepository;

        public EnderecoService(IRepository<Endereco> enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco Adicionar(Endereco Obj)
        {
            return _enderecoRepository.Adicionar(Obj);
        }

        public Endereco Atualizar(Endereco Obj)
        {
            return _enderecoRepository.Atualizar(Obj);
        }

        public async Task<IEnumerable<Endereco>> BuscarEnderecosCliente(int id)
        {
            return await _enderecoRepository.QueryGenerica().Where(e => e.ClienteId == id).ToListAsync();
        }

        public Task<Endereco> BuscarPorId(int id)
        {
            return  _enderecoRepository.BuscarPorId(id);
        }

        public async Task<IEnumerable<Endereco>> BuscarTodos()
        {
            return await _enderecoRepository.QueryGenerica().ToListAsync();

        }

        public void Remover(Endereco Obj)
        {
             _enderecoRepository.Remover(Obj);
        }
    }
}
