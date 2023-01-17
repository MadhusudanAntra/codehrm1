using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Services;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService submissionService;
        public SubmissionController(ISubmissionService submissionService)
        {
            this.submissionService = submissionService;
        }


        // GET: api/<SubmissionController>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllSubmissions()
        {
            var submission = await submissionService.GetAllSubmissions();
            /*
            if (!submission.Any() || submission.Count() == 0)
            {
                return NotFound();
            }
            */
            return Ok(submission);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetSubmission")]
        public async Task<ActionResult<SubmissionResponseModel>> GetSubmission(int id)
        {
            var sub = await submissionService.GetSubmissionByIdAsync(id);
            return Ok(sub);
        }

        // GET api/<SubmissionController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        [Route("addSubmission")]
        public async Task<IActionResult> Post(SubmissionRequestModel model)
        {
            if (model != null)
            {
                await submissionService.AddSubmissionAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "submission is deleted" };
            if (await submissionService.DeleteSubmissionAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Put(SubmissionRequestModel model)
        {
            var response = new { Message = "Submission is updated" };
            if (await submissionService.UpdateSubmissionAsync(model) > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
