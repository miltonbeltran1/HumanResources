using DAL.Contract.V1.Responses;
using DAL.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

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
                employee.Id = item.Id;
                employee.Name = item.Name;
                employee.ContractTypeName = item.ContractTypeName;
                employee.Role = new Role { RoleId = item.RoleId, RoleDescription = item.RoleDescription, RoleName = item.RoleName };
                employee.HourlySalary = item.HourlySalary;
                employee.MonthlySalary = item.MonthlySalary;
                employees.Add(employee);
            }
            return employees;
        }
    }
}
