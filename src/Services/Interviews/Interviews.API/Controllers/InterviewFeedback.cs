using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewFeedback : ControllerBase
{
    private readonly IInterviewFeedbackService _interviewFeedbackService;

    public InterviewFeedback(IInterviewFeedbackService interviewFeedbackService)
    {
        _interviewFeedbackService = interviewFeedbackService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<InterviewFeedbackResponseModel>> GetInterviewFeedback(int id)
    {
        var interviewFeedback = await _interviewFeedbackService.GetInterviewFeedbackById(id);
        return Ok(interviewFeedback);
    }

    [HttpPost]
    public async Task<ActionResult> CreateInterviewFeedback(
        [FromBody] InterviewFeedbackCreateOrUpdateRequestModel requestModel)
    {
        var createdInterviewFeedback = await _interviewFeedbackService.CreateInterviewFeedback(requestModel);
        return Created("CreateInterviewFeedback", createdInterviewFeedback);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateInterviewFeedback(int id,
        [FromBody] InterviewFeedbackCreateOrUpdateRequestModel requestModel)
    {
        if (id != requestModel.InterviewFeedbackId)
        {
            return BadRequest("Interview Feedback Id doesn't match");
        }
        var updatedInterviewFeedback = await _interviewFeedbackService.UpdateInterviewFeedback(requestModel);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteInterviewFeedback(InterviewFeedbackDeleteRequestModel requestModel)
    {
        await _interviewFeedbackService.DeleteInterviewFeedback(requestModel);
        return Ok();
    }
}