using AppNet6.Core.Entities;
using AppNet6.Core.Exceptions;
using AppNet6.Infrestructuras.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppNet6.Infrestructuras.Data;

namespace AppNet6.Infrestructuras.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppContextBD _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(AppContextBD context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int Id)
        {
            var ent = await _entities.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ent != null)
            {
                return ent;
            }
            else
            {
                throw new BusinessException("El Id del registro no existe");
            }

        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Update(T entity)
        {

            var ent = await GetById(entity.Id);

            if (ent != null)
            {
                _entities.Update(entity);
            }
            else
            {
                throw new BusinessException("El Id del registro no existe");
            }

        }

        public async Task Delete(int Id)
        {
            T entity = await GetById(Id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
            else
            {
                throw new RespuestaException("El registro ya se encuentra eliminado");
            }

        }
    }
}
