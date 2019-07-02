using System;
using System.Threading.Tasks;
using BaseOOPDAL.Entities;

namespace BaseOOPDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Developer> Developers { get; }
        IRepository<Designer> Designers { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Department> Departments { get; }
        void Commit();
        Task CommitAsync();
    }
}
