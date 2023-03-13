using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Services;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService employeeTypeService;
        public EmployeeTypeController(IEmployeeTypeService EmployeeTypeService)
        {
            this.employeeTypeService = EmployeeTypeService;
        }


        // GET: api/<EmployeeTypeController>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllEmployeeTypes()
        {
            var employeeType = await employeeTypeService.GetAllEmployeeTypes();
            /*
            if (!employeeType.Any() || employeeType.Count() == 0)
            {
                return NotFound();
            }
            */
            return Ok(employeeType);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetEmployeeType")]
        public async Task<ActionResult<EmployeeTypeResponseModel>> GetEmployeeType(int id)
        {
            var empType = await employeeTypeService.GetEmployeeTypeByIdAsync(id);
            return Ok(empType);
        }

        // GET api/<EmployeeTypeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addemployeetype")]
        public async Task<IActionResult> Post(EmployeeTypeRequestModel model)
        {
            if (model != null)
            {
                await employeeTypeService.AddEmployeeTypeAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "deleted" };
            if (await employeeTypeService.DeleteEmployeeTypeAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(EmployeeTypeRequestModel model)
        {
            var response = new { Message = "Employee Type is updated" };
            if (await employeeTypeService.UpdateEmployeeTypeAsync(model) > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
