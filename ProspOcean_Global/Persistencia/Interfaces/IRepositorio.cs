using ProspOcean_Global.Models;

namespace ProspOcean_Global.Persistencia.Interfaces
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int? id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        public interface IUsuarioRepositorio : IRepositorio<Usuario> { }
        public interface IEspecieRepositorio : IRepositorio<Especie> { }
        public interface IConservacaoRepositorio : IRepositorio<Conservacao> { }
        public interface IFavoritadasRepositorio : IRepositorio<Favoritadas> { }
    }
}
