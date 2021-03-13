using BAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Utility.Factory
{
    public class CalculateSalaryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public CalculateSalaryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public  ICalculateSalary GetSalaryFactory(string contractTypeName)
        {
            if (contractTypeName == "MonthlySalaryEmployee"){                
                return (ICalculateSalary)_serviceProvider.GetService(typeof(CalculateSalaryMonthly));
            }
            else
            {
                return (ICalculateSalary)_serviceProvider.GetService(typeof(CalculateSalaryHourly));                
            }
        }
    }
}
