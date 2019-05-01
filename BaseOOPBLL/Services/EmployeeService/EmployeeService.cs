using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _db;

        public EmployeeService()
        {
            _db = new UnitOfWork();
        }

        public void Create(EmployeeDto emp)
        {
            var manager = Mapper.Map<Manager>(emp.Manager);

            var employee = Mapper.Map<Employee>(emp);

            employee.Manager = manager;

            _db.Employees.Create(employee);

            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Employees.Delete(id);

            _db.Save();
        }

        public EmployeeDto Read(int id)
        {
            var employee = _db.Employees.Read(id);

            _db.Save();

            return Mapper.Map<EmployeeDto>(employee);
        }

        public IEnumerable<EmployeeDto> ReadAll()
        {
            var employee = _db.Employees.ReadAll();

            _db.Save();

            return Mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }

        public void Update(EmployeeDto emp)
        {
            var employee = _db.Employees.Read(emp.Id);

            if (employee != null)
            {
                var manager = Mapper.Map<Manager>(emp.Manager);

                employee = Mapper.Map<Employee>(emp);

                employee.Manager = manager;

                _db.Employees.Update(employee);

                _db.Save();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
