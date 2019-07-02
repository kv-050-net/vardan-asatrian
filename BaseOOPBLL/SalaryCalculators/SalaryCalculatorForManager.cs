using BaseOOPBLL.Entities;
using BaseOOPCompany;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class SalaryCalculatorForManager : SalaryCalculatorForEmployee
    {
        public override decimal Calculate(EmployeeDto employeeDto)
        {
            var manager = employeeDto as ManagerDto;

            decimal salary = GetSalaryByExperience(employeeDto);

            if (manager.Team.Count > 10)
            {
                salary += 300;
            }

            else if (manager.Team.Count > 5)
            {
                salary += 200;
            }

            if (IsDevelopersMoreThanTeamHalf(manager))
            {
                salary *= 1.1m;
            }

            return salary;
        }

        private bool IsDevelopersMoreThanTeamHalf(ManagerDto manager)
        {
            int developersCount = 0;

            foreach (var employee in manager.Team)
            {
                if (employee is DeveloperDto)
                    developersCount++;
            }

            if (developersCount > manager.Team.Count / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
