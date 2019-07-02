using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseOOPBLL.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task CreateOrUpdateAsync(TEntity item);
    }
}
