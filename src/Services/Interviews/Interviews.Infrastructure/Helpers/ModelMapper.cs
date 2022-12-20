using Interviews.ApplicationCore.DataModels.RequestModels;
using Interviews.ApplicationCore.DataModels.ResponseModels;
using Interviews.ApplicationCore.Entities;

namespace Interviews.Infrastructure.Helpers;

public static class ModelMapper
{
    public static InterviewTypeResponseModel ToInterviewTypeResponseModel(this InterviewType interviewType)
    {
        return new InterviewTypeResponseModel
        {
            LookupCode = interviewType.LookupCode,
            InterviewTypeName = interviewType.InterviewTypeName
        };
    }

    public static InterviewType ToInterviewType(this InterviewTypeCreateOrUpdateRequestModel requestModel)
    {
        return new InterviewType
        {
            LookupCode = requestModel.LookupCode,
            InterviewTypeName = requestModel.InterviewTypeName
        };
    }

    public static InterviewFeedback ToInterviewFeedback(this InterviewFeedbackCreateOrUpdateRequestModel requestModel)
    {
        return new InterviewFeedback
        {
            InterviewFeedbackId = requestModel.InterviewFeedbackId,
            Rating = requestModel.Rating,
            Comment = requestModel.Comment,
            InterviewId = requestModel.InterviewId
        };
    }

    public static InterviewFeedbackResponseModel ToInterviewFeedbackResponseModel(this InterviewFeedback interviewFeedback)
    {
        return new InterviewFeedbackResponseModel
        {
            InterviewFeedbackId = interviewFeedback.InterviewFeedbackId,
            Rating = interviewFeedback.Rating,
            Comment = interviewFeedback.Comment,
            InterviewId = interviewFeedback.InterviewId
        };
    }

    public static RecruiterResponseModel ToRecruiterResponseModel(this Recruiter recruiter)
    {
        return new RecruiterResponseModel
        {
            RecruiterId = recruiter.RecruiterId,
            FirstName = recruiter.FirstName,
            LastName = recruiter.LastName,
        };
    }

    public static Recruiter ToRecruiter(this RecruiterCreateOrUpdateRequestModel requestModel)
    {
        return new Recruiter
        {
            RecruiterId = requestModel.RecruiterId,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            EmployeeId = requestModel.EmployeeId
        };
    }

    public static Interviewer ToInterviewer(this InterviewerCreateOrUpdateRequestModel requestModel)
    {
        return new Interviewer
        {
            InterviewerId = requestModel.InterviewerId,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            EmployeeId = requestModel.EmployeeId
        };
    }

    public static InterviewerResponseModel ToInterviewerResponseModel(this Interviewer interviewer)
    {
        return new InterviewerResponseModel
        {
            InterviewerId = interviewer.InterviewerId,
            FirstName = interviewer.FirstName,
            LastName = interviewer.LastName
        };
    }

    public static InterviewResponseModel ToInterviewResponseModel(this Interview interview)
    {
        return new InterviewResponseModel
        {
            InterviewId = interview.InterviewerId,
            InterviewerId = interview.InterviewerId,
            RecruiterId = interview.RecruiterId,
            BeginTime = interview.BeginTime,
            EndTime = interview.EndTime,
            InterviewTypeCode = interview.InterviewTypeCode
        };
    }

    public static Interview ToInterview(this InterviewCreateOrUpdateRequestModel requestModel)
    {
        return new Interview
        {
            InterviewerId = requestModel.InterviewerId,
            SubmissionId = requestModel.SubmissionId,
            InterviewTypeCode = requestModel.InterviewTypeCode,
            RecruiterId = requestModel.RecruiterId,
            InterviewId = requestModel.InterviewId,
            BeginTime = requestModel.BeginTime,
            EndTime = requestModel.EndTime
        };
    }
}