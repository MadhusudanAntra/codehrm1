using System.Net;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewType : ControllerBase
{
    private readonly IInterviewTypeService _interviewTypeService;

    public InterviewType(IInterviewTypeService interviewTypeService)
    {
        _interviewTypeService = interviewTypeService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InterviewTypeResponseModel>>> GetAllInterviewTypes()
    {
        var interviewTypes = await _interviewTypeService.GetAllInterviewType();
        return Ok(interviewTypes);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<InterviewTypeResponseModel>> GetInterviewTypeById(int id)
    {
        var interviewType = await _interviewTypeService.GetInterviewTypeById(id);
        return Ok(interviewType);
    }

    [HttpPost]
    public async Task<ActionResult> CreateInterviewType(
        [FromBody] InterviewTypeCreateOrUpdateRequestModel requestModel)
    {
        var createdInterviewType = await _interviewTypeService.CreateInterviewType(requestModel);
        //return Request.CreateResponse(HttpStatusCode.Created, createdInterviewType);
        //return Ok(createdInterviewType);
        return Created("CreateInterviewType",createdInterviewType);
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateInterviewType(int id,
        [FromBody] InterviewTypeCreateOrUpdateRequestModel requestModel)
    {
        if (id != requestModel.LookupCode)
        {
            return BadRequest("Interview type lookup code doesn't match");
        }
        var updatedInterviewType = await _interviewTypeService.UpdateInterviewType(requestModel);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteInterviewType(int id)
    {
        await _interviewTypeService.DeleteInterviewType(id);
        return Ok();
    }
}