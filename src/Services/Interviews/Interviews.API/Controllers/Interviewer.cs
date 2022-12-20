using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Interviewer : ControllerBase
{
    private readonly IInterviewerService _interviewerService;

    public Interviewer(IInterviewerService interviewerService)
    {
        _interviewerService = interviewerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InterviewerResponseModel>>> GetAllInterviewers()
    {
        var interviewers = await _interviewerService.GetAllInterviewers();
        return Ok(interviewers);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<InterviewerResponseModel>> GetInterviewerById(int id)
    {
        var interviewer = await _interviewerService.GetInterviewerById(id);
        return Ok(interviewer);
    }

    [HttpPost]
    public async Task<ActionResult> CreateInterviewer([FromBody] InterviewerCreateOrUpdateRequestModel requestModel)
    {
        var createdInterviewer = await _interviewerService.CreateInterviewer(requestModel);
        return Created("CreateInterviewer", createdInterviewer);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateInterviewer([FromBody] InterviewerCreateOrUpdateRequestModel requestModel)
    {
        var updatedInterviewer = await _interviewerService.UpdateInterviewer(requestModel);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteInterviewer(int id)
    {
        await _interviewerService.DeleteInterviewer(id);
        return Ok();
    }
}