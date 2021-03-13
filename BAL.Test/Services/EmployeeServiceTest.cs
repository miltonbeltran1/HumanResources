using AutoMapper;
using BAL.Implementation;
using BAL.Interfaces;
using BAL.Utility.Factory;
using DAL.Domain.Entities;
using DAL.Repository;
using DAL.Utility;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;
using BAL.Models;

namespace BAL.Test
{
    public class EmployeeServiceTest
    {
        private Task<List<Employee>> employees;
        private List<EmployeeDTO> employeesDTO;
        private Mock<EmployeeRepository> employeeRepository;
        private Mock<IMapper> mockMapper;
        private CalculateSalaryFactory calculateSalaryFactory;
        public EmployeeServiceTest()
        {
            LoadEmployees();
            LoadEmployeesDTO();
            SetUpMocks();

        }

        private void SetUpMocks()
        {
            var configuration = new Mock<IConfiguration>();
            var clientFactory = new Mock<IHttpClientFactory>();
            var mapperToDAO = new Mock<IMapperToDAO>();
            employeeRepository = new Mock<EmployeeRepository>(configuration.Object, clientFactory.Object, mapperToDAO.Object);
            employeeRepository.Setup(mock => mock.GetAll()).Returns(employees);
            mockMapper = new Mock<IMapper>();
            var _mockService = new Mock<IServiceProvider>();
            _mockService.Setup(mock => mock.GetService(typeof(CalculateSalaryMonthly))).Returns(new CalculateSalaryMonthly());
            _mockService.Setup(mock => mock.GetService(typeof(CalculateSalaryHourly))).Returns(new CalculateSalaryHourly());
            calculateSalaryFactory = new CalculateSalaryFactory(_mockService.Object);
            
        }

        [Fact]
        public void ValidateGetAllEmployees()
        {
            // Arrange
            mockMapper.Setup(x => x.Map<List<Employee>,List<EmployeeDTO>>(It.IsAny<List<Employee>>())).Returns(employeesDTO);
            IEmployeeService primeService = new EmployeeService(employeeRepository.Object, mockMapper.Object, calculateSalaryFactory);

            // Act
            var result =  primeService.GetAllAsync();

            // Assert
            Assert.NotNull(result.Result);
            Assert.True(result.Result.Success == true);
            Assert.True(result.Result.Messagge == "OK");
            Assert.True(((List<EmployeeDTO>)result.Result.Data).Count == 2);

        }

        [Fact]
        public void VerifyCalculateSalaryMonthly()
        {
            // Arrange
            var idEmployee = 2;
            mockMapper.Setup(x => x.Map<Employee, EmployeeDTO>(It.IsAny<Employee>())).Returns(employeesDTO.Find(x=>x.ContractTypeName== "MonthlySalaryEmployee"));
            IEmployeeService primeService = new EmployeeService(employeeRepository.Object, mockMapper.Object, calculateSalaryFactory);

            // Act
            var result = primeService.GetAsync(idEmployee);

            // Assert
            Assert.NotNull(result.Result);
            Assert.True(result.Result.Success == true);
            Assert.True(result.Result.Messagge == "OK");
            Assert.True(((EmployeeDTO)result.Result.Data).AnnualSalary == 600000);
            Assert.True(((EmployeeDTO)result.Result.Data).Id == 2);

        }

        [Fact]
        public void VerifyCalculateSalaryHourly()
        {
            // Arrange
            var idEmployee = 1;
            mockMapper.Setup(x => x.Map<Employee, EmployeeDTO>(It.IsAny<Employee>())).Returns(employeesDTO.Find(x => x.ContractTypeName == "HourlySalaryEmployee"));
            IEmployeeService primeService = new EmployeeService(employeeRepository.Object, mockMapper.Object, calculateSalaryFactory);

            // Act
            var result = primeService.GetAsync(idEmployee);

            // Assert
            Assert.NotNull(result.Result);
            Assert.True(result.Result.Success == true);
            Assert.True(result.Result.Messagge == "OK");
            Assert.True(((EmployeeDTO)result.Result.Data).AnnualSalary == 14400000);
            Assert.True(((EmployeeDTO)result.Result.Data).Id == 1);

        }

        [Fact]
        public void ValidateNoMatchesFound()
        {
            // Arrange
            var idEmployee = 1;           
            IEmployeeService primeService = new EmployeeService(employeeRepository.Object, mockMapper.Object, calculateSalaryFactory);

            // Act
            var result = primeService.GetAsync(idEmployee);

            // Assert
            Assert.NotNull(result.Result);
            Assert.Null(result.Result.Data);
            Assert.True(result.Result.Success == true);
            Assert.True(result.Result.Messagge == "OK");
        }

        private void LoadEmployeesDTO()
        {
            employeesDTO = new List<EmployeeDTO>{
                new EmployeeDTO()
            {
                Id = 1,
                Name = "Camilo",
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 10000,
                MonthlySalary = 50000,
                Role =  new RoleDTO { RoleId = 1, RoleDescription = "", RoleName = "Administrator" }
            }, new EmployeeDTO()
            {
                Id = 2,
                Name = "Camila",
                ContractTypeName = "MonthlySalaryEmployee",
                HourlySalary = 10000,
                MonthlySalary = 50000,
                Role =  new RoleDTO { RoleId = 2, RoleDescription = "", RoleName = "Contractor" }
            }
            };
        }

        private void LoadEmployees()
        {
            employees = Task.Run(() => new List<Employee>{
                new Employee()
            {
                Id = 1,
                Name = "Camilo",
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 10000,
                MonthlySalary = 50000,
                Role =  new Role { RoleId = 1, RoleDescription = "", RoleName = "Administrator" }
            }, new Employee()
            {
                Id = 2,
                Name = "Camila",
                ContractTypeName = "MonthlySalaryEmployee",
                HourlySalary = 10000,
                MonthlySalary = 50000,
                Role =  new Role { RoleId = 2, RoleDescription = "", RoleName = "Contractor" }
            }
            });
        }
    }
}
