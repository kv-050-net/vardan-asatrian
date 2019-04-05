using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public interface ISalaryCalculatorFactory
    {
        ISalaryCalculator CreateCalculator();
    }
}
