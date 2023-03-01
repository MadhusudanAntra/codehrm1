using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        //In Memory caching IMemoryCache object creation
        private readonly IMemoryCache _memoryCache;
        public JobRequirementController(IJobRequirementService jobRequirementService, IMemoryCache memoryCache)
        {
            this.jobRequirementService = jobRequirementService;
            //Injecting cache object in constructor
            _memoryCache = memoryCache;
        }


        // GET: api/<JobRequirementController>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllJobRequirements()
        {
            //Check if job requirements are already in cache
            if (_memoryCache.TryGetValue("all", out IEnumerable<JobRequirementResponseModel> jobRequirements))
            {
                //If so, return cached job requirements
                return Ok(jobRequirements);

            }
            //Else fetch the job requirements again from DB and then add them to cache
            else
            {
                var jobRequirement = await jobRequirementService.GetAllJobRequirements();

                //Configure cache entry options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetPriority(CacheItemPriority.Normal)
                    //SetSize function refers to number of cache entries that the cache can hold. In this case 1024 jobs is the limit
                    .SetSize(1024);

                //add item to cache with the key "all" and the cache entry options object
                _memoryCache.Set("all", jobRequirement, cacheEntryOptions);
        
                /*
                if (!jobRequirement.Any() || jobRequirement.Count() == 0)
                {
                    return NotFound();
                }
                */
                return Ok(jobRequirement);
            }
            
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetJobRequirement")]
        public async Task<ActionResult<JobRequirementResponseModel>> GetJobRequirement(int id)
        {
            var jR = await jobRequirementService.GetJobRequirementByIdAsync(id);
            return Ok(jR);
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
        [Route("delete-{id}")]
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
