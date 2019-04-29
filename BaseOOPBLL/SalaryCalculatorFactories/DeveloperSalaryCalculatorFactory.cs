using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class DeveloperSalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public ISalaryCalculator CreateCalculator()
        {
            return new SalaryCalculatorForDeveloper();
        }
    }
}
