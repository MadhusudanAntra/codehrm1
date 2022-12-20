using System.Globalization;
using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Entities;
using Interviews.ApplicationCore.Exceptions;
using Interviews.Infrastructure.Helpers;

namespace Interviews.Infrastructure.Services;

public class InterviewFeedbackService : IInterviewFeedbackService
{
    private readonly IInterviewFeedbackRepository _interviewFeedbackRepository;

    public InterviewFeedbackService(IInterviewFeedbackRepository interviewFeedbackRepository)
    {
        _interviewFeedbackRepository = interviewFeedbackRepository;
    }
    public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackById(int id)
    {
        var interviewFeedback = await _interviewFeedbackRepository.GetById(id);
        if (interviewFeedback == null)
        {
            throw new NotFoundException("InterviewFeedback", id);
        }

        var response = interviewFeedback.ToInterviewFeedbackResponseModel();
        return response;
    }

    public async Task<InterviewFeedbackResponseModel> CreateInterviewFeedback(InterviewFeedbackCreateOrUpdateRequestModel requestModel)
    {
        var interviewFeedback = requestModel.ToInterviewFeedback();
        var createdInterviewFeedback = await _interviewFeedbackRepository.Create(interviewFeedback);
        var response = createdInterviewFeedback.ToInterviewFeedbackResponseModel();
        return response;
    }

    public async Task<InterviewFeedbackResponseModel> UpdateInterviewFeedback(InterviewFeedbackCreateOrUpdateRequestModel requestModel)
    {
        var interviewFeedback = requestModel.ToInterviewFeedback();
        var createdInterviewFeedback = await _interviewFeedbackRepository.Update(interviewFeedback);
        var response = createdInterviewFeedback.ToInterviewFeedbackResponseModel();
        return response;
    }
    

    public async Task DeleteInterviewFeedback(InterviewFeedbackDeleteRequestModel requestModel)
    {
        int id = requestModel.InterviewFeedbackId;
        await _interviewFeedbackRepository.Delete(id);
    }
}