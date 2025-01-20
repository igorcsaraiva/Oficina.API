using Oficina.API.Context;
using Oficina.API.Models;

namespace Oficina.API.Repository
{
    public class Repository<T> : IRepository<T> where T : Entidade
    {
        private readonly OficinaContext _oficinaContext;

        public Repository(OficinaContext oficinaContext)
        {
            _oficinaContext = oficinaContext;
        }

        public T Adicionar(T Obj)
        {
            _oficinaContext.Add(Obj);
            _oficinaContext.SaveChanges();

            return Obj;
        }

        public T Atualizar(T Obj)
        {
            _oficinaContext.Update(Obj);
            _oficinaContext.SaveChanges();

            return Obj;
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _oficinaContext.FindAsync<T>(id);
        }

        public IQueryable<T> QueryGenerica()
        {
            return  _oficinaContext.Set<T>();
        }

        public void Remover(T Obj)
        {
            _oficinaContext.Remove(Obj);
            _oficinaContext.SaveChanges();
        }
    }
}
