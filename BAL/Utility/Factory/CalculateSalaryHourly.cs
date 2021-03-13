using BAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Utility.Factory
{
    public class CalculateSalaryHourly : ICalculateSalary
    {        
        public CalculateSalaryHourly()
        {     
        }

        public decimal Calculate(EmployeeDTO Employee)
        {
            return 120 * Employee.hourlySalary * 12;
        }
    }
}
