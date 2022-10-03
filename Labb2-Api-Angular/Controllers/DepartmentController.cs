using Labb2_Api_Angular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Labb2_Api_Angular.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
         
    {

        private readonly IDepartment _IDepartment;

        public DepartmentController(IDepartment departmentContext)
        {
            _IDepartment = departmentContext;
        }

        //get all Department
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var department = await _IDepartment.GetAll();
            return Ok(department);
        }
        //get single Department
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetSingleDepartment")]
        public async Task<IActionResult> GetSingleDepartment([FromRoute]Guid id)
        {
            var department = await _IDepartment.GetById(id);
            if (department != null)
            {
                return Ok(department);
            }

                return NotFound("department not found");
            
        }

        //Add new Department
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody]Department department)
        {

            await _IDepartment.Insert(department);
            return CreatedAtAction(nameof(GetSingleDepartment),new { id = department.DepartmentId}, department);
        }
        //update Department
        [HttpPut]
        [Route("{id=guid}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute]Guid id, Department department)
        {
            await _IDepartment.UpdateById(id, department);
            if (department == null)
            {
                return NotFound("department not found");
            }
            return Ok(department);  
        }
        //delete Department
        [HttpDelete]
        [Route("{id=guid}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute]Guid id)
        {
           
            if (id != null)
            {
                await _IDepartment.DeleteById(id);
                return Ok("Department deleted");
            }
            return NotFound("Department not found to delete.");

        }
    }
}
