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
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly IEmployeeCategoryService _employeeCategoryService;

        public EmployeeCategoryController(IEmployeeCategoryService employeeCategoryService)
        {
            _employeeCategoryService = employeeCategoryService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<EmployeeCategoryInfoModel>>> GetAllEmployeeCategories()
        {
            var employeeCategories = await _employeeCategoryService.GetAll();
            return Ok(employeeCategories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<EmployeeCategoryInfoModel>> GetEmployeeCategoryByID(int id)
        {
            var employeeCategory = await _employeeCategoryService.GetById(id);
            return Ok(employeeCategory);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<EmployeeCategoryInfoModel>> AddEmployeeCategory([FromBody] EmployeeCategoryCreateModel employeeCategory)
        {
            var newEmployeeCategory = await _employeeCategoryService.Add(employeeCategory);
            return Created("AddEmployeeCategory", newEmployeeCategory);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<ActionResult<EmployeeCategoryInfoModel>> UpdateEmployeeCategory(int id, [FromBody] EmployeeCategoryCreateModel employeeCategory)
        {
            var updatedEmployeeCategory = new EmployeeCategoryInfoModel
            {
                CategoryID = id,
                Name = employeeCategory.Name,
                Description = employeeCategory.Description
            };

            var result = await _employeeCategoryService.Update(updatedEmployeeCategory);
            return Ok(employeeCategory);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> DeleteEmployeeCategory(int id)
        {
            var employeeCategory = await _employeeCategoryService.Delete(id);
            return Ok(employeeCategory);
        }
    }
}
