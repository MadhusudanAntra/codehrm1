using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Services;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;
        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }


        // GET: api/<StatusController>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllStatus()
        {
            var status = await statusService.GetAllStatus();
            /*
            if (!status.Any() || status.Count() == 0)
            {
                return NotFound();
            }
            */
            return Ok(status);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStatus")]
        public async Task<ActionResult<StatusResponseModel>> GetStatus(int id)
        {
            var stat = await statusService.GetStatusByIdAsync(id);
            return Ok(stat);
        }
        // GET api/<StatusController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        [Route("addStatus")]
        public async Task<IActionResult> Post(StatusRequestModel model)
        {
            if (model != null)
            {
                await statusService.AddStatusAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "Status is deleted" };
            if (await statusService.DeleteStatusAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Put(StatusRequestModel model)
        {
            var response = new { Message = "status is updated" };
            if (await statusService.UpdateStatusAsync(model) > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
