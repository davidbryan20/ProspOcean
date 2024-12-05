using Microsoft.EntityFrameworkCore;
using ProspOcean_Global.Models;
using ProspOcean_Global.Persistencia;
using System;
using ProspOcean_Global.Persistencia.Interfaces;
using ProspOcean_GS.Repositories;

namespace ProspOcean_Global.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class

    {
        private readonly ProspOceanDbContext _context;

        private readonly DbSet<T> _dbSet;

        public Repositorio(ProspOceanDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);

            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
        {
            public UsuarioRepositorio(ProspOceanDbContext context) : base(context) { }

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
}