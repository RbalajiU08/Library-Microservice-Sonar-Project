using EmployeeServices.Model;
using EmployeeServices.UnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServices.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeUnitofWork _unitofwork;
        public EmployeeController(IEmployeeUnitofWork unitofwork) 
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public async Task<IActionResult> GetallDatas()
        {
            return Ok(await _unitofwork.employeeRepository.GetallEmployee());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatabyId(int id)
        {
            var empdata = await _unitofwork.employeeRepository.GetEmployeebyId(id);
            if(empdata is null)
            {
                return NoContent();
            }
            return Ok(empdata);
        }
        [HttpPost]
        public async Task<IActionResult> InsertData(Employee employee)
        {
            await _unitofwork.employeeRepository.AddEmployee(employee);
            await _unitofwork.SaveDatas();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(int id,Employee employee)
        {
            var empdata = await _unitofwork.employeeRepository.GetEmployeebyId(id);
            if (empdata is null)
            {
                return NoContent();
            }
            await _unitofwork.employeeRepository.UpdateEmployee(employee,id);
            await _unitofwork.SaveDatas();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var empdata = await _unitofwork.employeeRepository.GetEmployeebyId(id);
            if (empdata is null)
            {
                return NoContent();
            }
            await _unitofwork.employeeRepository.DeleteEmployee(id);
            await _unitofwork.SaveDatas();
            return Ok();
        }
    }
}
