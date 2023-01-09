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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<EmployeeInfoModel>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<EmployeeInfoModel>> GetEmployeeByID(int id)
        {
            var employee = await _employeeService.GetById(id);
            return Ok(employee);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<EmployeeInfoModel>> AddEmployee([FromBody] EmployeeCreateModel employee)
        {
            var newEmployee = await _employeeService.Add(employee);
            return Created("AddEmployee", newEmployee);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<ActionResult<EmployeeInfoModel>> UpdateEmployee(int id, [FromBody] EmployeeCreateModel employee)
        {
            var updatedEmployee = new EmployeeInfoModel
            {
                EmployeeId = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeRoleId = employee.EmployeeRoleId
            };

            var result = await _employeeService.Update(updatedEmployee);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            var employee = await _employeeService.Delete(id);
            return Ok(employee);
        }
    }
}
