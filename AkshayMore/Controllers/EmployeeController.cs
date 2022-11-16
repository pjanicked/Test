using AkshayMore.Model;
using AkshayMore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AkshayMore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _employeeRepository.GetEmployee(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await _employeeRepository.CreateEmployee(employee);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            await _employeeRepository.UpdateEmployee(employee);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.DeleteEmployee(id);

            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
