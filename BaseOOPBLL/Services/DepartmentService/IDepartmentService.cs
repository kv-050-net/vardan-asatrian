using BaseOOPBLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPBLL.Services.DepartmentService
{
    public interface IDepartmentService : IService<DepartmentDto>
    {
        void PaySalary();
        void AccrueSalary(EmployeeDto employeeDto);

    }
}
