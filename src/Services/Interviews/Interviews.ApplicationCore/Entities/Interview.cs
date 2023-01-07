using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.ApplicationCore.Entities;

public class Interview
{
    public int InterviewId { get; set; }
    public int InterviewerId { get; set; }
    public int InterviewTypeCode { get; set; }
    public int RecruiterId { get; set; }
    public int SubmissionId { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    
    //Navigation properties
    public Interviewer? Interviewer { get; set; }
    public InterviewType? InterviewType { get; set; }
    public Recruiter? Recruiter { get; set; }
}