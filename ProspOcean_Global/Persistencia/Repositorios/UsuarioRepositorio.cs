using ProspOcean_Global.Models;
using ProspOcean_Global.Persistencia;
using ProspOcean_Global.Repositorios;
using ProspOcean_GS.Repositories;
using System;

namespace ProspOcean_GS.Repositorios
{
    public class UsuarioRepository : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepository(ProspOceanDbContext context) : base(context) { }

        public Task<Usuario> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
