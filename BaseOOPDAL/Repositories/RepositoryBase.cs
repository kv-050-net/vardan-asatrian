using BaseOOPDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseOOPDAL.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _dbset;

        public RepositoryBase(Context context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryble()
        {
            return _dbset.AsQueryable<TEntity>();
        }

        public async Task CreateOrUpdateAsync(TEntity item)
        {
            if (item.Id == 0)
                await _dbset.AddAsync(item);
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
    }
}
