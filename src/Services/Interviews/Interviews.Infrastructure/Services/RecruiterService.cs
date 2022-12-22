using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Exceptions;
using Interviews.Infrastructure.Helpers;

namespace Interviews.Infrastructure.Services;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;

    public RecruiterService(IRecruiterRepository recruiterRepository)
    {
        _recruiterRepository = recruiterRepository;
    }
    public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters()
    {
        var recruiters = await _recruiterRepository.GetAll();
        var response = recruiters.Select(r => r.ToRecruiterResponseModel());
        return response;
    }

    public async Task<RecruiterResponseModel> GetRecruiterById(int id)
    {
        var recruiter = await _recruiterRepository.GetById(id);
        if (recruiter == null)
        {
            throw new NotFoundException();
        }
        var response = recruiter.ToRecruiterResponseModel();
        return response;
    }

    public async Task<RecruiterResponseModel> CreateRecruiter(RecruiterCreateOrUpdateRequestModel requestModel)
    {
        var createdRecruiter = requestModel.ToRecruiter();
        var recruiter = await _recruiterRepository.Create(createdRecruiter);
        var response = recruiter.ToRecruiterResponseModel();
        return response;
    }

    public async Task<RecruiterResponseModel> UpdateRecruiter(RecruiterCreateOrUpdateRequestModel requestModel)
    {
        var createdRecruiter = requestModel.ToRecruiter();
        var recruiter = await _recruiterRepository.Update(createdRecruiter);
        var response = recruiter.ToRecruiterResponseModel();
        return response;
    }

    public async Task DeleteRecruiter(int id)
    {
        await _recruiterRepository.Delete(id);
    }
}