using DAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Utility
{
    public interface IMapperToDAO
    {
        public List<Employee> MapperEmployee(string jsonEmployees);
    }
}
