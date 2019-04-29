using BaseOOPBLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public class SalaryCalculatorForDesigner : SalaryCalculatorForEmployee
    {
        public override decimal Calculate(EmployeeDto employeeDto)
        {
            var designer = employeeDto as DesignerDto;

            return GetSalaryByExperience(employeeDto) * designer.EffectivenessCoefficient;
        }
    }
}
