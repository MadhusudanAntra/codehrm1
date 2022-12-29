using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Models;

namespace OnBoarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleService _employeeRoleService;

        public EmployeeRoleController(IEmployeeRoleService employeeRoleService)
        {
            _employeeRoleService = employeeRoleService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<EmployeeRoleInfoModel>>> GetAllEmployeeRoles()
        {
            var employeeRoles = await _employeeRoleService.GetAll();
            return Ok(employeeRoles);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<EmployeeRoleInfoModel>> GetEmployeeRoleByID(int id)
        {
            var employeeRole = await _employeeRoleService.GetById(id);
            return Ok(employeeRole);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<EmployeeRoleInfoModel>> AddEmployeeRole([FromBody] EmployeeRoleCreateModel employeeRole)
        {
            var newEmployeeRole = await _employeeRoleService.Add(employeeRole);
            return Created("AddEmployeeRole", newEmployeeRole);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<ActionResult<EmployeeRoleInfoModel>> UpdateEmployeeRole(int id, [FromBody] EmployeeRoleCreateModel employeeRole)
        {
            var updatedEmployeeRole = new EmployeeRoleInfoModel
            {
                RoleID = id,
                Name = employeeRole.Name,
                Description = employeeRole.Description
            };

            var result = await _employeeRoleService.Update(updatedEmployeeRole);
            return Ok(employeeRole);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> DeleteEmployeeRole(int id)
        {
            var employeeRole = await _employeeRoleService.Delete(id);
            return Ok(employeeRole);
        }
    }
}
