using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Contracts.Services;
using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Exceptions;
using Interviews.Infrastructure.Helpers;

namespace Interviews.Infrastructure.Services;

public class InterviewerService : IInterviewerService
{
    private readonly IInterviewerRepository _interviewerRepository;

    public InterviewerService(IInterviewerRepository interviewerRepository)
    {
        _interviewerRepository = interviewerRepository;
    }
    public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers()
    {
        var interviewers = await _interviewerRepository.GetAll();
        var response = interviewers.Select(i => i.ToInterviewerResponseModel());
        return response;
    }

    public async Task<InterviewerResponseModel> GetInterviewerById(int id)
    {
        var interviewer = await _interviewerRepository.GetById(id);
        if (interviewer == null)
        {
            throw new NotFoundException();
        }

        var response = interviewer.ToInterviewerResponseModel();
        return response;
    }

    public async Task<InterviewerResponseModel> CreateInterviewer(InterviewerCreateOrUpdateRequestModel requestModel)
    {
        var createdInterviewer = requestModel.ToInterviewer();
        var interviewer = await _interviewerRepository.Create(createdInterviewer);
        var response = interviewer.ToInterviewerResponseModel();
        return response;
    }

    public async Task<InterviewerResponseModel> UpdateInterviewer(InterviewerCreateOrUpdateRequestModel requestModel)
    {
        var updatedInterviewer = requestModel.ToInterviewer();
        var interviewer = await _interviewerRepository.Update(updatedInterviewer);
        var response = interviewer.ToInterviewerResponseModel();
        return response;
    }

    public async Task DeleteInterviewer(int id)
    {
        await _interviewerRepository.Delete(id);
    }
}