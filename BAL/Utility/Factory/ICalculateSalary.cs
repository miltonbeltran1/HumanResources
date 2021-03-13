using BAL.Models;

namespace BAL.Utility.Factory
{
    public interface ICalculateSalary
    {
        public decimal Calculate(EmployeeDTO employee);
    }
}
