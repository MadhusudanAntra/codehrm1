using Interviews.ApplicationCore.Constants;

namespace Interviews.ApplicationCore.DataModels.ResponseModels;

public class InterviewFeedbackResponseModel
{
    public int InterviewFeedbackId { get; set; }
    public Rating Rating { get; set; }
    public string? Comment { get; set; }
    public int InterviewId { get; set; }
}