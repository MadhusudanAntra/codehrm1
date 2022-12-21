using System.ComponentModel.Design;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Interview : ControllerBase
{
    private readonly IInterviewService _interviewService;

    public Interview(IInterviewService interviewService)
    {
        _interviewService = interviewService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InterviewResponseModel>>> GetAllInterviews()
    {
        var interviews = await _interviewService.GetAllInterviews();
        return Ok(interviews);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<InterviewResponseModel>> GetInterviewById(int id)
    {
        var interview = await _interviewService.GetInterviewById(id);
        return Ok(interview);
    }
    
    [HttpGet]
    [Route("interviewer/{id:int}")]
    public async Task<ActionResult<IEnumerable<InterviewResponseModel>>> GetInterviewByInterviewer(int id)
    {
        var interviews = await _interviewService.GetInterviewsByInterviewerId(id);
        return Ok(interviews);
    }

    [HttpPost]
    public async Task<ActionResult> CreateInterview([FromBody] InterviewCreateOrUpdateRequestModel requestModel)
    {
        var createdInterview = await _interviewService.CreateInterview(requestModel);
        return Created("CreateInterview", createdInterview);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateInterview(int id, [FromBody] InterviewCreateOrUpdateRequestModel requestModel)
    {
        if (id != requestModel.InterviewId)
        {
            return BadRequest("Interview Id doesn't match");
        }
        
        var updatedInterview = await _interviewService.UpdateInterview(requestModel);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteInterview(int id)
    {
        await _interviewService.DeleteInterview(id);
        return Ok();
    }
}