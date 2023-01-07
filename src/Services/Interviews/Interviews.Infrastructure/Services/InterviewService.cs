using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Exceptions;
using Interviews.Infrastructure.Helpers;

namespace Interviews.Infrastructure.Services;

public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _interviewRepository;

    public InterviewService(IInterviewRepository interviewRepository)
    {
        _interviewRepository = interviewRepository;
    }
    
    public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviews()
    {
        var interviews = await _interviewRepository.GetAll();
        var response = interviews.Select(i => i.ToInterviewResponseModel());
        return response;
    }

    public async Task<InterviewResponseModel> GetInterviewById(int id)
    {
        var interview = await _interviewRepository.GetById(id);
        if (interview == null)
        {
            throw new NotFoundException();
        }
        var response = interview.ToInterviewResponseModel();
        return response;
    }

    public async Task<InterviewResponseModel> CreateInterview(InterviewCreateOrUpdateRequestModel requestModel)
    {
        var createdInterview = requestModel.ToInterview();
        var interview = await _interviewRepository.Create(createdInterview);
        var response = interview.ToInterviewResponseModel();
        return response;
    }

    public async Task<InterviewResponseModel> UpdateInterview(InterviewCreateOrUpdateRequestModel requestModel)
    {
        var updatedInterview = requestModel.ToInterview();
        var interview = await _interviewRepository.Update(updatedInterview);
        var response = interview.ToInterviewResponseModel();
        return response;
    }

    public async Task DeleteInterview(int id)
    {
        await _interviewRepository.Delete(id);
    }

    public async Task<IEnumerable<InterviewResponseModel>> GetInterviewsByInterviewerId(int interviewerId)
    {
        var interviews = await _interviewRepository.GetInterviewByInterviewer(interviewerId);
        var response = interviews.Select(i => i.ToInterviewResponseModel());
        return response;
    }

    public async Task<IEnumerable<InterviewResponseModel>> GetInterviewsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }
}