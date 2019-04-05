using BaseOOPCompany;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class SalaryCalculatorForManager : SalaryCalculatorForEmployee
    {
        public override decimal Calculate(Employee employee)
        {
            Manager manager = employee as Manager;

            decimal salary = GetSalaryByExperience(employee);

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

        private bool IsDevelopersMoreThanTeamHalf(Manager manager)
        {
            int developersCount = 0;

            foreach (var employee in manager.Team)
            {
                if (employee is Developer)
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
