using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using BaseOOPDAL.Repositories;
using System;
using System.Threading.Tasks;

namespace BaseOOPDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context { get; }
        private IRepository<Employee> _employee;
        private IRepository<Developer> _developer;
        private IRepository<Designer> _designer;
        private IRepository<Manager> _manager;
        private IRepository<Department> _department;
        private bool _disposed = false;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (_employee == null)
                    _employee = new RepositoryBase<Employee>(_context);
                return _employee;
            }
        }

        public IRepository<Developer> Developers
        {
            get
            {
                if (_developer == null)
                    _developer = new RepositoryBase<Developer>(_context);
                return _developer;
            }
        }

        public IRepository<Designer> Designers
        {
            get
            {
                if (_designer == null)
                    _designer = new RepositoryBase<Designer>(_context);
                return _designer;
            }
        }

        public IRepository<Manager> Managers
        {
            get
            {
                if (_manager == null)
                    _manager = new RepositoryBase<Manager>(_context);
                return _manager;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (_department == null)
                    _department = new RepositoryBase<Department>(_context);
                return _department;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
