using BAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Utility.Factory
{
    public class CalculateSalaryMonthly : ICalculateSalary
    {
        public CalculateSalaryMonthly()
        {
        }

        public decimal Calculate(EmployeeDTO employee)
        {
            return employee.monthlySalary * 12;
        }
    }
}
