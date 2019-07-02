using BaseOOPBLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseOOPCompany
{
    public interface ISalaryCalculator
    {
        decimal Calculate(EmployeeDto employeeDto);
    }
}
