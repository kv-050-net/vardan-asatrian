using System;

namespace BaseOOPCompany
{
    public class Developer : Employee
    {
        public Developer(string firstName, string secondName, decimal salary, int experience, Manager manager = null)
            : base(firstName, secondName, salary, experience, manager)
        {

        }
    }
}
