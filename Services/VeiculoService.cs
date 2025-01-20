using Microsoft.EntityFrameworkCore;
using Oficina.API.Models;
using Oficina.API.Repository;

namespace Oficina.API.Services
{
    public class VeiculoService : IVeiculoService
    {
        public readonly IRepository<Veiculo> _veiculoRepository;

        public VeiculoService(IRepository<Veiculo> veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public Veiculo Adicionar(Veiculo Obj)
        {
            return _veiculoRepository.Adicionar(Obj);
        }

        public Veiculo Atualizar(Veiculo Obj)
        {
            return _veiculoRepository.Atualizar(Obj);
        }

        public Task<Veiculo> BuscarPorId(int id)
        {
            return _veiculoRepository.BuscarPorId(id);
        }

        public async Task<IEnumerable<Veiculo>> BuscarTodos()
        {
            return await _veiculoRepository.QueryGenerica().ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> BuscarVeiculosCliente(int id)
        {
            return await _veiculoRepository.QueryGenerica().Where(v => v.ClienteId == id).ToListAsync();
        }

        public void Remover(Veiculo Obj)
        {
            _veiculoRepository.Remover(Obj);
        }
    }
}
