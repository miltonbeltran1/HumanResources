using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Routes.V1;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _IEmployeeService;

        public EmployeeController(IEmployeeService pmployeeService)
        {
            _IEmployeeService = pmployeeService;
        }

        [HttpGet(ApiRoutes.Employee.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _IEmployeeService.GetAllAsync());
        }

        [HttpGet(ApiRoutes.Employee.Get)]
        public async Task<IActionResult> Get(int filter)
        {
            return Ok(await _IEmployeeService.GetAsync(filter));
        }
    }
}
