using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;

namespace Interviews.ApplicationCore.Contracts.Services;

public interface IInterviewFeedbackService
{
    Task<InterviewFeedbackResponseModel> GetInterviewFeedbackById(int id);

    Task<InterviewFeedbackResponseModel> CreateInterviewFeedback(
        InterviewFeedbackCreateOrUpdateRequestModel interviewFeedbackCreateOrUpdateRequestModel);
    Task<InterviewFeedbackResponseModel> UpdateInterviewFeedback(
        InterviewFeedbackCreateOrUpdateRequestModel interviewFeedbackCreateOrUpdateRequestModel);

    Task DeleteInterviewFeedback(InterviewFeedbackDeleteRequestModel interviewFeedbackDeleteRequest);
}