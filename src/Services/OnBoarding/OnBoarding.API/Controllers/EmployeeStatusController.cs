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
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusService _employeeStatusService;

        public EmployeeStatusController(IEmployeeStatusService employeeStatusService)
        {
            _employeeStatusService = employeeStatusService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<EmployeeStatusInfoModel>>> GetAllEmployeeStatuss()
        {
            var employeeStatuss = await _employeeStatusService.GetAll();
            return Ok(employeeStatuss);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<EmployeeStatusInfoModel>> GetEmployeeStatusByID(int id)
        {
            var employeeStatus = await _employeeStatusService.GetById(id);
            return Ok(employeeStatus);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<EmployeeStatusInfoModel>> AddEmployeeStatus([FromBody] EmployeeStatusCreateModel employeeStatus)
        {
            var newEmployeeStatus = await _employeeStatusService.Add(employeeStatus);
            return Created("AddEmployeeStatus", newEmployeeStatus);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<ActionResult<EmployeeStatusInfoModel>> UpdateEmployeeStatus(int id, [FromBody] EmployeeStatusCreateModel employeeStatus)
        {
            var updatedEmployeeStatus = new EmployeeStatusInfoModel
            {
                StatusID = id,
                Name = employeeStatus.Name,
                Description = employeeStatus.Description
            };

            var result = await _employeeStatusService.Update(updatedEmployeeStatus);
            return Ok(employeeStatus);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> DeleteEmployeeStatus(int id)
        {
            var employeeStatus = await _employeeStatusService.Delete(id);
            return Ok(employeeStatus);
        }
    }
}
