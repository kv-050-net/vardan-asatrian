using BaseOOPBLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPBLL.Services.DepartmentService
{
    public interface IDepartmentService : IService<DepartmentDto>
    {
        void PaySalary(DepartmentDto dep);
        void PaySalaryParallel(DepartmentDto dep);
        void AccrueSalary(EmployeeDto employeeDto);

    }
}
