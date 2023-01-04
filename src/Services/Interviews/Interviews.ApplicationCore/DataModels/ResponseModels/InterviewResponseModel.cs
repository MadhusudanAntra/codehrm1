namespace Interviews.ApplicationCore.DataModels.ResponseModels;

//removed submissionId 
public class InterviewResponseModel
{
    public int InterviewId { get; set; }
    public int InterviewerId { get; set; }
    public int InterviewTypeCode { get; set; }
    public int RecruiterId { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
}