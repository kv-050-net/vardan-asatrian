using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPDAL.Repositories
{
    class DepartmentRepository : IRepository<Department>
    {
        private readonly Context _context;

        public DepartmentRepository(Context context)
        {
            _context = context;
        }

        public void Create(Department item)
        {
            _context.Departments.Add(item);
        }

        public void Delete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department != null)
                _context.Departments.Remove(department);
        }

        public Department Read(int id)
        {
            return _context.Departments.Find(id);
        }

        public IEnumerable<Department> ReadAll()
        {
            return _context.Departments;
        }

        public void Update(Department item)
        {
            _context.Departments.Update(item);
        }
    }
}
