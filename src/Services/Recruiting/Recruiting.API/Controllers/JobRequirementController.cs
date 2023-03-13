using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;
using System.Text.Json;
using Recruiting.Infrastructure.Services;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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
        private readonly IDistributedCache _RedisCache;
        public JobRequirementController(IJobRequirementService jobRequirementService, IMemoryCache memoryCache, IDistributedCache RedisCache)
        {
            this.jobRequirementService = jobRequirementService;
            //Injecting cache object in constructor
            _memoryCache = memoryCache;
            _RedisCache = RedisCache;
        }


        // GET: api/<JobRequirementController>
        //Redis Caching version of the function
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllJobRequirements()
        {
            //Check if job requirements are already in Redis cache
            var jobRequirements = await _RedisCache.GetStringAsync("all");
            if (jobRequirements != null)
            {
                //If so, we first Decode the bytes into a JSON string then Deserialize the JSON string to get our data
                var result = JsonSerializer.Deserialize<IEnumerable<JobRequirementResponseModel>>(jobRequirements);
                return Ok(result);

            }
            //Else fetch the job requirements again from DB and then add them to Redis cache
            else
            {
                var jobRequirement = await jobRequirementService.GetAllJobRequirements();
                //Serialize job requirements to JSON from DB
                var cachedJobRequirements = JsonSerializer.Serialize(jobRequirement);

                //Configuring cache entry options
                var cacheEntryOptions = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                //Putting JSON in Redis Cache to be retrieved the next time method is called
                await _RedisCache.SetStringAsync("all", cachedJobRequirements, cacheEntryOptions);
        
                /*
                if (!jobRequirement.Any() || jobRequirement.Count() == 0)
                {
                    return NotFound();
                }
                */
                return Ok(jobRequirements);
            }
            
        }

        //In-Memory Caching Version of the Function
        //[HttpGet]
        //[Route("getall")]
        //public async Task<IActionResult> GetAllJobRequirements()
        //{
        //    //Check if job requirements are already in cache
        //    if (_memoryCache.TryGetValue("all", out IEnumerable<JobRequirementResponseModel> jobRequirements))
        //    {
        //        //If so, return cached job requirements
        //        return Ok(jobRequirements);

        //    }
        //    //Else fetch the job requirements again from DB and then add them to cache
        //    else
        //    {
        //        var jobRequirement = await jobRequirementService.GetAllJobRequirements();

        //        //Configure cache entry options
        //        var cacheEntryOptions = new MemoryCacheEntryOptions()
        //            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
        //            .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
        //            .SetPriority(CacheItemPriority.Normal)
        //            //SetSize function refers to number of cache entries that the cache can hold. In this case 1024 jobs is the limit
        //            .SetSize(1024);

        //        //add item to cache with the key "all" and the cache entry options object
        //        _memoryCache.Set("all", jobRequirement, cacheEntryOptions);

        //        /*
        //        if (!jobRequirement.Any() || jobRequirement.Count() == 0)
        //        {
        //            return NotFound();
        //        }
        //        */
        //        return Ok(jobRequirement);
        //    }

        //}

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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "deleted" };
            if (await jobRequirementService.DeleteJobRequirementAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }
        
        [Authorize(Roles = "Admin")]
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
