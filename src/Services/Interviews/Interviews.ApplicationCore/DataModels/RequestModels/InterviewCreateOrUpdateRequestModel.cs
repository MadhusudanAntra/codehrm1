using System.ComponentModel.DataAnnotations;

namespace Interviews.ApplicationCore.DataModels.RequestModels;

public class InterviewCreateOrUpdateRequestModel
{
    public int InterviewId { get; set; }
    public int InterviewerId { get; set; }
    public int InterviewTypeCode { get; set; }
    public int RecruiterId { get; set; }
    public int SubmissionId { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime BeginTime { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }
}