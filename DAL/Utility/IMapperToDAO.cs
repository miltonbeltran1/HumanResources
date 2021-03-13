using DAL.Domain.Entities;
using System.Collections.Generic;

namespace DAL.Utility
{
    public interface IMapperToDAO
    {
        public List<Employee> MapperEmployee(string jsonEmployees);
    }
}
