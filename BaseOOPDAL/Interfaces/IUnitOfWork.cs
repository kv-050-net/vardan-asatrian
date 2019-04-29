using System;
using BaseOOPDAL.Entities;

namespace BaseOOPDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Developer> Developers { get; }
        IRepository<Designer> Designers { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Department> Departments { get; }
        void Save();
    }
}
