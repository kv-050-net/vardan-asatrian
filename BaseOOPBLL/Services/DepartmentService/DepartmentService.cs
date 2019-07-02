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
        private readonly IUnitOfWork _uow;
        private readonly IDictionary<Type, ISalaryCalculator> _calculatorsDictionary;
        private ISalaryCalculator _salaryCalculator;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _calculatorsDictionary = new Dictionary<Type, ISalaryCalculator>
            {
                [typeof(DeveloperDto)] = new DeveloperSalaryCalculatorFactory().CreateCalculator(),
                [typeof(DesignerDto)] = new DesignerSalaryCalculatorFactory().CreateCalculator(),
                [typeof(ManagerDto)] = new ManagerSalaryCalculatorFactory().CreateCalculator()
            };
        }

        public async Task CreateOrUpdateAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            await _uow.Departments.CreateOrUpdateAsync(department);
            await _uow.CommitAsync();
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
