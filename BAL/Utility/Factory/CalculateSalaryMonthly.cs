using BAL.Models;

namespace BAL.Utility.Factory
{
    public class CalculateSalaryMonthly : ICalculateSalary
    {
        public decimal Calculate(EmployeeDTO employee)
        {
            return employee.MonthlySalary * 12;
        }
    }
}
