using BaseOOPBLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public abstract class SalaryCalculatorForEmployee : ISalaryCalculator
    {
        public virtual decimal Calculate(EmployeeDto employeeDto)
        {
            return GetSalaryByExperience(employeeDto);
        }

        protected decimal GetSalaryByExperience(EmployeeDto employeeDto)
        {
            decimal salary = employeeDto.Salary;

            if (employeeDto.Experience > 5)
            {
                salary = salary * 1.20m + 500;
            }

            else if (employeeDto.Experience > 2)
            {
                salary += 200;
            }

            return salary;
        }
    }
}
