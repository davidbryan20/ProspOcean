using ProspOcean_Global.Models;
using ProspOcean_Global.Persistencia.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspOcean_GS.Repositories
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetByNameAsync(string name);
    }
}
