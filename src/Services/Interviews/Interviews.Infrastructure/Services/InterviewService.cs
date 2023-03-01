using System.Net.Http.Json;
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
    private readonly HttpClient _httpClient;

    public InterviewService(IInterviewRepository interviewRepository, HttpClient httpClient)
    {
        _interviewRepository = interviewRepository;
        _httpClient = httpClient;
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
        //get submission ID from frontend request
        var submissionId = interview.SubmissionId;
        //get submission object from recruiting microservice
        var submission = await _httpClient.GetFromJsonAsync<SubmissionResponseModel>($"api/Submission/{submissionId}");
        //update status -- missing property
        submission.CurrentStatus = "Interview Created";
        //make a put request to update status
        HttpResponseMessage updateSubmissionResponse = await _httpClient.PutAsJsonAsync($"api/Submission/put", submission);
        if (!updateSubmissionResponse.IsSuccessStatusCode)
        {
            throw new Exception("Submission status has not been updated successfully");
        }
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