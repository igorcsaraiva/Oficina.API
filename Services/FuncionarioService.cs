using Microsoft.EntityFrameworkCore;
using Oficina.API.Models;
using Oficina.API.Repository;

namespace Oficina.API.Services
{
    public class FuncionarioService : IService<Funcionario>
    {
        public readonly IRepository<Funcionario> _funcionarioRepository;

        public FuncionarioService(IRepository<Funcionario> funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public Funcionario Adicionar(Funcionario Obj)
        {
            return _funcionarioRepository.Adicionar(Obj);
        }

        public Funcionario Atualizar(Funcionario Obj)
        {
            return _funcionarioRepository.Atualizar(Obj);
        }

        public async Task<Funcionario> BuscarPorId(int id)
        {
            return await _funcionarioRepository.BuscarPorId(id);
        }

        public async Task<IEnumerable<Funcionario>> BuscarTodos()
        {
            return await _funcionarioRepository.QueryGenerica().Include(f => f.OrdemServicos).ToListAsync();
        }

        public void Remover(Funcionario Obj)
        {
            _funcionarioRepository.Remover(Obj);
        }
    }
}
