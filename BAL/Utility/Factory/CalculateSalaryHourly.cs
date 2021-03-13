using BAL.Models;

namespace BAL.Utility.Factory
{
    public class CalculateSalaryHourly : ICalculateSalary
    {        
        public decimal Calculate(EmployeeDTO Employee)
        {
            return 120 * Employee.HourlySalary * 12;
        }
    }
}
