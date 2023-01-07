using System.ComponentModel.DataAnnotations.Schema;
using Interviews.ApplicationCore.Constants;

namespace Interviews.ApplicationCore.Entities;

public class InterviewFeedback
{
    public int InterviewFeedbackId { get; set; }
    public Rating Rating { get; set; }
    public string? Comment { get; set; }
    public int InterviewId { get; set; }
    
    //Navigation Property
    public Interview? Interview { get; set; }
}