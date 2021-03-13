using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain.Entities
{
    public class Employee
    {
        public long id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public Role role { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }

    }

    

}
