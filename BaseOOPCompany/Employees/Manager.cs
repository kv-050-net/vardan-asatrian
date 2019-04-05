using System;
using System.Collections.Generic;

namespace BaseOOPCompany
{
    public class Manager : Employee
    {
        private List<Employee> team;

        public List<Employee> Team
        {
            get
            {
                return team;
            }

            set
            {
                if (value == null)
                {
                    team = new List<Employee>();
                }

                team = value;
            }
        }

        public void AddTeamMember(Employee employee)
        {
            Team.Add(employee);
        }

        public void RemoveTeamMember(Employee employee)
        {
            Team.Remove(employee);
        }

        public Manager(string firstName, string secondName, decimal salary, int experience, Manager manager = null, List<Employee> team = null)
            : base(firstName, secondName, salary, experience, manager)
        {
            Team = team;
        }
    }
}
