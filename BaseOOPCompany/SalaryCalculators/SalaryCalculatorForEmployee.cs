using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public abstract class SalaryCalculatorForEmployee : ISalaryCalculator
    {
        public virtual decimal Calculate(Employee employee)
        {
            return GetSalaryByExperience(employee);
        }

        protected decimal GetSalaryByExperience(Employee employee)
        {
            decimal salary = employee.Salary;

            if (employee.Experience > 5)
            {
                salary = salary * 1.20m + 500;
            }

            else if (employee.Experience > 2)
            {
                salary += 200;
            }

            return salary;
        }
    }
}
