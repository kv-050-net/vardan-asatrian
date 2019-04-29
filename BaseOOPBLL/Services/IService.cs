using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPBLL.Services
{
    public interface IService<T> : IDisposable where T : class
    {
        void Create(T item);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }
}
