using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPDAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public void Create(Employee item)
        {
            _context.Employees.Add(item);
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
                _context.Employees.Remove(employee);
        }

        public Employee Read(int id)
        {
            return _context.Employees.Find(id);
        }

        public IEnumerable<Employee> ReadAll()
        {
            return _context.Employees;
        }

        public void Update(Employee item)
        {
            _context.Employees.Update(item);
        }
    }
}
