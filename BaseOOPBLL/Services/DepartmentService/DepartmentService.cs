using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPCompany;
using BaseOOPDAL;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _db;
        private readonly IDictionary<Type, ISalaryCalculator> _calculatorsDictionary;
        private ISalaryCalculator _salaryCalculator;

        public DepartmentService()
        {
            _db = new UnitOfWork();
            _calculatorsDictionary = new Dictionary<Type, ISalaryCalculator>
            {
                [typeof(DeveloperDto)] = new DeveloperSalaryCalculatorFactory().CreateCalculator(),
                [typeof(DesignerDto)] = new DesignerSalaryCalculatorFactory().CreateCalculator(),
                [typeof(ManagerDto)] = new ManagerSalaryCalculatorFactory().CreateCalculator()
            };
        }

        public void Create(DepartmentDto dep)
        {
            var managers = Mapper.Map<List<Manager>>(dep.Managers);

            var department = Mapper.Map<Department>(dep);

            department.Managers = managers;

            _db.Departments.Create(department);

            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Departments.Delete(id);

            _db.Save();
        }

        public DepartmentDto Read(int id)
        {
            var department = _db.Departments.Read(id);

            _db.Save();

            return Mapper.Map<DepartmentDto>(department);
        }

        public IEnumerable<DepartmentDto> ReadAll()
        {
            var department = _db.Departments.ReadAll();

            _db.Save();

            return Mapper.Map<IEnumerable<DepartmentDto>>(department);
        }

        public void Update(DepartmentDto dep)
        {
            var department = _db.Departments.Read(dep.Id);

            if (department != null)
            {
                var managers = Mapper.Map<List<Manager>>(dep.Managers);

                department = Mapper.Map<Department>(dep);

                department.Managers = managers;

                _db.Departments.Update(department);

                _db.Save();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void PaySalary(DepartmentDto dep)
        {
            foreach (var manager in dep.Managers)
            {
                AccrueSalary(manager);

                foreach (var teamMember in manager.Team)
                {
                    AccrueSalary(teamMember);
                }
            }
        }

        public void PaySalaryParallel(DepartmentDto dep)
        {
            Parallel.ForEach(dep.Managers, (manager) =>
            {
                AccrueSalary(manager);

                Parallel.ForEach(manager.Team, (teamMember) =>
                {
                    AccrueSalary(teamMember);
                });
            });
        }

        public void AccrueSalary(EmployeeDto employeeDto)
        {
            _salaryCalculator = _calculatorsDictionary[employeeDto.GetType()];

            Console.WriteLine($"{employeeDto.FirstName} {employeeDto.SecondName}: got salary: {_salaryCalculator.Calculate(employeeDto).ToString("0.00")}. Thread - {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
