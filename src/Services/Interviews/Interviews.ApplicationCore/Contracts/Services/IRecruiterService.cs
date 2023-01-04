using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Entities;

namespace Interviews.ApplicationCore.Contracts.Services;

public interface IRecruiterService
{
    Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters();
    Task<RecruiterResponseModel> GetRecruiterById(int id);
    Task<RecruiterResponseModel> CreateRecruiter(RecruiterCreateOrUpdateRequestModel requestModel);
    Task<RecruiterResponseModel> UpdateRecruiter(RecruiterCreateOrUpdateRequestModel requestModel);
    Task DeleteRecruiter(int id);
}