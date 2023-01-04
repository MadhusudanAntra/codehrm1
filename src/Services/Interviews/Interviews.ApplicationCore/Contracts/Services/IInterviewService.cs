using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;

namespace Interviews.ApplicationCore.Contracts.Services;

public interface IInterviewService
{
    Task<IEnumerable<InterviewResponseModel>> GetAllInterviews();
    Task<InterviewResponseModel> GetInterviewById(int id);
    Task<InterviewResponseModel> CreateInterview(InterviewCreateOrUpdateRequestModel requestModel);
    Task<InterviewResponseModel> UpdateInterview(InterviewCreateOrUpdateRequestModel requestModel);
    Task DeleteInterview(int id);
    Task<IEnumerable<InterviewResponseModel>> GetInterviewsByInterviewerId(int interviewerId);
    Task<IEnumerable<InterviewResponseModel>> GetInterviewsByDate(DateTime date);
}