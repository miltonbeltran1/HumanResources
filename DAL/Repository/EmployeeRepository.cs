using CommonUtility.Exceptions;
using DAL.Domain.Entities;
using DAL.Utility;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmployeeRepository : BaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;
        private readonly IMapperToDAO _mapperToDAO;
        public EmployeeRepository(IConfiguration configuration, IHttpClientFactory clientFactory, IMapperToDAO mapperToDAO) : base()
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient("EmployeeClient");
            _mapperToDAO = mapperToDAO;
        }

        public override async Task<List<Employee>> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _configuration.GetSection("EmployeeService:GetAllEmployees").Value);
            var response = await _client.SendAsync(request);
           
            if (!response.IsSuccessStatusCode)
                throw new ApiException(response.StatusCode);
            
            var employees = _mapperToDAO.MapperEmployee(await response.Content.ReadAsStringAsync());
            
            return employees;
        }
    }
}
