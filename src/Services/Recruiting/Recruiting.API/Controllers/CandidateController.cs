using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllCandidate()
        {
            var candidates = await candidateService.GetAllCandidates();
            
            /*
            if(!candidates.Any() || candidates.Count() == 0)
            {
                return NotFound();
            }
            */
            
            return Ok(candidates);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetCandidate")]
        public async Task<ActionResult<CandidateResponseModel>> GetCandidate(int id)
        {
            var candidate = await candidateService.GetCandidateByIdAsync(id);
            return Ok(candidate);
        }

        [HttpPost]
        [Route("addcandidate")]
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            if (model!= null)
            {
                await candidateService.AddCandidateAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "deleted" };
            if (await candidateService.DeleteCandidateAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Put(CandidateRequestModel model)
        {
            var response = new { Message = "Candidate is updated" };
            if (await candidateService.UpdateCandidateAsync(model) > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
