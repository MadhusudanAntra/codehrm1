using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;

namespace Interviews.ApplicationCore.Contracts.Services;

public interface IInterviewerService
{
    Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers();
    Task<InterviewerResponseModel> GetInterviewerById(int id);
    Task<InterviewerResponseModel> CreateInterviewer(InterviewerCreateOrUpdateRequestModel requestModel);
    Task<InterviewerResponseModel> UpdateInterviewer(InterviewerCreateOrUpdateRequestModel requestModel);
    Task DeleteInterviewer(int id);
}