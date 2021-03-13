using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public RoleDTO Role { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}
