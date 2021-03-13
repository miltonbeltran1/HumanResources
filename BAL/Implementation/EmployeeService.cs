using AutoMapper;
using BAL.Interfaces;
using BAL.Models;
using BAL.Utility.Factory;
using CommonUtility.Helpers;
using CommonUtility.Models.V1;
using DAL.Domain.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL.Implementation
{
    public class EmployeeService : IEmployeeService
    { 
        private readonly EmployeeRepository _repository;
        private readonly CalculateSalaryFactory _calculateSalaryFactory;
        private readonly IMapper _mapper;
        public EmployeeService(EmployeeRepository repository, IMapper mapper, CalculateSalaryFactory calculateSalaryFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _calculateSalaryFactory = calculateSalaryFactory;
        }

        public async Task<BaseResponse> GetAllAsync()
        {
            try
            {               
                List<Employee> employees = await _repository.GetAll();
                List<EmployeeDTO> employeesResponse = _mapper.Map<List<Employee>, List<EmployeeDTO>>(employees);
                foreach(var employee in employeesResponse)
                {                    
                    CalculateSalary(employee);
                }
                return ResponseHelper.SetResponse(true, "OK", employeesResponse);
            }
            catch (Exception ex)
            {
                return ResponseHelper.SetResponse(false, ex.Message, ex.InnerException);
            }                   
        }

        public async Task<BaseResponse> GetAsync(int filter)
        {
            try
            {
                var employees = await _repository.GetAll();
                var employee = employees.Find(item => item.Id == filter);
                EmployeeDTO employeeResponse = _mapper.Map<Employee, EmployeeDTO>(employee);
                if (employeeResponse != null)
                    CalculateSalary(employeeResponse);
                return ResponseHelper.SetResponse(true, "OK", employeeResponse);
            }
            catch (Exception ex)
            {
                return ResponseHelper.SetResponse(false, ex.Message, ex.InnerException);
            }
        }

        private void CalculateSalary(EmployeeDTO employee)
        {
            employee.AnnualSalary = _calculateSalaryFactory.GetSalaryFactory(employee.ContractTypeName).Calculate(employee);
        }
    }
}
