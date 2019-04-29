using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using BaseOOPDAL.Repositories;

namespace BaseOOPDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context { get; }
        private IRepository<Developer> _developer;
        private IRepository<Designer> _designer;
        private IRepository<Manager> _manager;
        private IRepository<Department> _department;

        public UnitOfWork()
        {
            _context = new Context();
        }

        public IRepository<Developer> Developers
        {
            get
            {
                if (_developer == null)
                    _developer = new DeveloperRepository(_context);
                return _developer;
            }
        }

        public IRepository<Designer> Designers
        {
            get
            {
                if (_designer == null)
                    _designer = new DesignerRepository(_context);
                return _designer;
            }
        }

        public IRepository<Manager> Managers
        {
            get
            {
                if (_manager == null)
                    _manager = new ManagerRepository(_context);
                return _manager;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (_department == null)
                    _department = new DepartmentRepository(_context);
                return _department;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
