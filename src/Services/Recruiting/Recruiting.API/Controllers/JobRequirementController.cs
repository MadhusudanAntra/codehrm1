using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementService jobRequirementService;
        public JobRequirementController(IJobRequirementService jobRequirementService)
        {
            this.jobRequirementService = jobRequirementService;
        }


        // GET: api/<JobRequirementController>
        [HttpGet]
        public async Task<IActionResult> GetAllJobRequirements()
        {
            var jobRequirement = await jobRequirementService.GetAllJobRequirements();
            if (!jobRequirement.Any() || jobRequirement.Count == 0)
            {
                return NotFound();
            }
            return Ok(jobRequirement);
        }

        // GET api/<JobRequirementController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        [Route("addjobrequirement")]
        public async Task<IActionResult> Post(JobRequirementRequestModel model)
        {
            if (model != null)
            {
                await jobRequirementService.AddJobRequirementAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "deleted" };
            if (await jobRequirementService.DeleteJobRequirementAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Put(JobRequirementRequestModel model)
        {
            var response = new { Message = "Job Requirement is updated" };
            if (await jobRequirementService.UpdateJobRequirementAsync(model) > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
