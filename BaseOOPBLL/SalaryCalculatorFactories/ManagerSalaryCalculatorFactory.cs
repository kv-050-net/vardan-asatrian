using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class ManagerSalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public ISalaryCalculator CreateCalculator()
        {
            return new SalaryCalculatorForManager();
        }
    }
}
