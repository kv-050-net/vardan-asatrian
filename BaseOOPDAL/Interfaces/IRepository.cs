using System.Linq;
using System.Threading.Tasks;

namespace BaseOOPDAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task CreateOrUpdateAsync(TEntity item);
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> AsQueryble();
        Task DeleteAsync(int id);
        void Delete(TEntity entity);
    }
}
