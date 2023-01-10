using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;

namespace Interviews.ApplicationCore.Contracts.Services;

public interface IInterviewTypeService
{
    Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewType();
    Task<InterviewTypeResponseModel> GetInterviewTypeById(int id);
    Task<InterviewTypeResponseModel> CreateInterviewType(InterviewTypeCreateOrUpdateRequestModel requestModel);
    Task<InterviewTypeResponseModel> UpdateInterviewType(InterviewTypeCreateOrUpdateRequestModel requestModel);
    Task DeleteInterviewType(int id);
}