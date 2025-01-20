using Oficina.API.Models;

namespace Oficina.API.Services
{
    public interface IService<T> where T : Entidade
    {
        public T Adicionar(T Obj);
        public T Atualizar(T Obj);
        public Task<T> BuscarPorId(int id);
        public void Remover(T Obj);
        public Task<IEnumerable<T>> BuscarTodos();
    }
}
