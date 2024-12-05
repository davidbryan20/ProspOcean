using Microsoft.EntityFrameworkCore;
using ProspOcean_Global.Models;

namespace ProspOcean_Global.Persistencia
{
    public class ProspOceanDbContext : DbContext
    {
        public DbSet<Conservacao> Conservacoes { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Favoritadas> Favoritadas { get; set; }

        public ProspOceanDbContext(DbContextOptions<ProspOceanDbContext> options) : base(options)
        {

        }
    }
}
