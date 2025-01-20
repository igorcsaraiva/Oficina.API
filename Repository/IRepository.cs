using Oficina.API.Models;

namespace Oficina.API.Repository
{
    public interface IRepository<T> where T : Entidade
    {
        public T Adicionar(T Obj);
        public T Atualizar(T Obj);
        public Task<T> BuscarPorId(int id);
        public IQueryable<T> QueryGenerica();
        public void Remover(T Obj);
    }
}
