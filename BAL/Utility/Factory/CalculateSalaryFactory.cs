using System;

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
            return contractTypeName == "MonthlySalaryEmployee" ?
                (ICalculateSalary)_serviceProvider.GetService(typeof(CalculateSalaryMonthly)) :
                (ICalculateSalary)_serviceProvider.GetService(typeof(CalculateSalaryHourly));
        }
    }
}
