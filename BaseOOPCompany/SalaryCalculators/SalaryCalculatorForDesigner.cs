using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class SalaryCalculatorForDesigner : SalaryCalculatorForEmployee
    {
        public override decimal Calculate(Employee employee)
        {
            Designer designer = employee as Designer;

            return GetSalaryByExperience(employee) * designer.EffectivenessCoefficient;
        }
    }
}
