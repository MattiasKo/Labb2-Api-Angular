using Labb2_Api_Angular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Labb2_Api_Angular.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
         
    {

        private readonly IEmployee _IEmployee;

        public EmployeeController(IEmployee employeeContext)
        {
            _IEmployee = employeeContext;
        }

        //get all employee
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await _IEmployee.GetAll();
            return Ok(employee);
        }
        //get single employee
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetSingleEmployee")]
        public async Task<IActionResult> GetSingleEmployee([FromRoute]Guid id)
        {
            var employee = await _IEmployee.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }

                return NotFound("Employee not found");
            
        }

        //Add new employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {

            await _IEmployee.Insert(employee);
            return CreatedAtAction(nameof(GetSingleEmployee),new { id = employee.EmployeeId}, employee);
        }
        //update emplpyee
        [HttpPut]
        [Route("{id=guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]Guid id,Employee employee)
        {
            await _IEmployee.UpdateById(id, employee);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);  
        }
        //delete employee
        [HttpDelete]
        [Route("{id=guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]Guid id)
        {
           
            if (id != null)
            {
                await _IEmployee.DeleteById(id);
                return Ok("Employee deleted");
            }
            return NotFound("Employee not found to delete.");

        }
    }
}
