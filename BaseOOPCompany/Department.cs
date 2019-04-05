﻿using System;
using System.Collections.Generic;

namespace BaseOOPCompany
{
    public class Department
    {
        public List<Manager> Managers { get; }

        private ISalaryCalculator salaryCalculator;

        private IDictionary<Type, ISalaryCalculator> calculatorsDictionary = new Dictionary<Type, ISalaryCalculator>
        {
            [typeof(Developer)] = new DeveloperSalaryCalculatorFactory().CreateCalculator(),
            [typeof(Designer)] = new DesignerSalaryCalculatorFactory().CreateCalculator(),
            [typeof(Manager)] = new ManagerSalaryCalculatorFactory().CreateCalculator()
        };

        public void AddManager(Manager manager)
        {
            Managers.Add(manager);
        }

        public void RemoveManager(Manager manager)
        {
            Managers.Remove(manager);
        }

        public Department(List<Manager> managers)
        {
            Managers = managers;
        }

        // Paying salary for all employees
        public void PaySalary()
        {
            foreach (var manager in Managers)
            {
                AccrueSalary(manager);

                foreach (var teamMember in manager.Team)
                {
                    AccrueSalary(teamMember);
                }
            }
        }

        // Accruing salary for one employee
        public void AccrueSalary(Employee employee)
        {
            salaryCalculator = calculatorsDictionary[employee.GetType()];

            Console.WriteLine($"{employee.FirstName} {employee.SecondName}: got salary: {salaryCalculator.Calculate(employee).ToString("0.00")}");
        }
    }
}
