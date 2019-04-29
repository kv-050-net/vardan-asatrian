using System;
using System.Collections.Generic;

namespace BaseOOPDAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }
}
