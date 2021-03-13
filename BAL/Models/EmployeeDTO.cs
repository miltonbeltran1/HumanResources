using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    public class EmployeeDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public RoleDTO role { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
        public decimal annualSalary { get; set; }
    }
}
