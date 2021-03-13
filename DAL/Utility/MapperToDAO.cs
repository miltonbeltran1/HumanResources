using DAL.Contract.V1.Responses;
using DAL.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Utility
{
    public class MapperToDAO : IMapperToDAO
    {
        public List<Employee> MapperEmployee(string jsonEmployees)
        {
            List<EmployeeResponse> listEmployees = JsonConvert.DeserializeObject<List<EmployeeResponse>>(jsonEmployees);
            List<Employee> employees = new List<Employee>();
            foreach (var item in listEmployees)
            {
                Employee employee = new Employee();
                employee.id = item.id;
                employee.name = item.name;
                employee.contractTypeName = item.contractTypeName;
                employee.role = new Role { roleId = item.roleId, roleDescription = item.roleDescription, roleName = item.roleName };
                employee.hourlySalary = item.hourlySalary;
                employee.monthlySalary = item.monthlySalary;
                employees.Add(employee);
            }
            return employees;
        }
    }
}
