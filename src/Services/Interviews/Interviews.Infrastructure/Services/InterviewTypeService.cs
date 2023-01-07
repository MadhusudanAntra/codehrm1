using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Exceptions;
using Interviews.Infrastructure.Helpers;

namespace Interviews.Infrastructure.Services;

public class InterviewTypeService : IInterviewTypeService
{
    private readonly IInterviewTypeRepository _interviewTypeRepository;

    public InterviewTypeService(IInterviewTypeRepository interviewTypeRepository)
    {
        _interviewTypeRepository = interviewTypeRepository;
    }
    
    public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewType()
    {
        var interviewTypes =  await _interviewTypeRepository.GetAll();
        var response = interviewTypes.Select(t => t.ToInterviewTypeResponseModel());
        return response;
    }

    public async Task<InterviewTypeResponseModel> GetInterviewTypeById(int id)
    {
        var interviewType = await _interviewTypeRepository.GetById(id);
        if (interviewType == null)
        {
            throw new NotFoundException();
        }
        var response = interviewType.ToInterviewTypeResponseModel();
        return response;
    }

    public async Task<InterviewTypeResponseModel> CreateInterviewType(InterviewTypeCreateOrUpdateRequestModel requestModel)
    {
        var createdInterviewType = requestModel.ToInterviewType();
        var interviewType = await _interviewTypeRepository.Create(createdInterviewType);
        var response = interviewType.ToInterviewTypeResponseModel();
        return response;
    }

    public async Task<InterviewTypeResponseModel> UpdateInterviewType(InterviewTypeCreateOrUpdateRequestModel requestModel)
    {
        var createdInterviewType = requestModel.ToInterviewType();
        var interviewType = await _interviewTypeRepository.Update(createdInterviewType);
        var response = interviewType.ToInterviewTypeResponseModel();
        return response;
    }

    public async Task DeleteInterviewType(int id)
    {
        await _interviewTypeRepository.Delete(id);
    }
}