using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Recruiter : ControllerBase
{
    private readonly IRecruiterService _recruiterService;

    public Recruiter(IRecruiterService recruiterService)
    {
        _recruiterService = recruiterService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecruiterResponseModel>>> GetAllRecruiters()
    {
        var recruiters = await _recruiterService.GetAllRecruiters();
        return Ok(recruiters);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<RecruiterResponseModel>> GetRecruiterById(int id)
    {
        var recruiter = await _recruiterService.GetRecruiterById(id);
        return Ok(recruiter);
    }

    [HttpPost]
    public async Task<ActionResult> CreateRecruiter([FromBody] RecruiterCreateOrUpdateRequestModel requestModel)
    {
        var createdRecruiter = await _recruiterService.CreateRecruiter(requestModel);
        return Created("CreateRecruiter", createdRecruiter);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateRecruiter(int id, [FromBody] RecruiterCreateOrUpdateRequestModel requestModel)
    {
        if (id != requestModel.RecruiterId)
        {
            return BadRequest("Recruiter id doesn't match");
        }
        var updatedRecruiter = await _recruiterService.UpdateRecruiter(requestModel);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteRecruiter(int id)
    {
        await _recruiterService.DeleteRecruiter(id);
        return Ok();
    }
}