using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class DesignerSalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public ISalaryCalculator CreateCalculator()
        {
            return new SalaryCalculatorForDesigner();
        }
    }
}
