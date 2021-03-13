using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain.Entities
{
    public class Employee
    {
        public long Id {get; set;}
        public string Name {get; set;}
        public string ContractTypeName {get; set;}
        public Role Role {get; set;}
        public decimal HourlySalary {get; set;}
        public decimal MonthlySalary {get; set;}

    }

    

}
