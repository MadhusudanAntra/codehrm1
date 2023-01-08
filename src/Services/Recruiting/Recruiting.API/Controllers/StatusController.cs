using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;

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
        public async Task<IActionResult> GetAllStatuss()
        {
            var status = await statusService.GetAllStatus();
            if (!status.Any() || status.Count == 0)
            {
                return NotFound();
            }
            return Ok(status);
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
        [Route("{id}")]
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
