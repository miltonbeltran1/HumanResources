using BAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Utility.Factory
{
    public interface ICalculateSalary
    {
        public decimal Calculate(EmployeeDTO employee);
    }
}
