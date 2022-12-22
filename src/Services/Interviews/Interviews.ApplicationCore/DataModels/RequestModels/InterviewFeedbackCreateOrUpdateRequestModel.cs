using System.ComponentModel.DataAnnotations;
using Interviews.ApplicationCore.Constants;

namespace Interviews.ApplicationCore.DataModels.RequestModels;

public class InterviewFeedbackCreateOrUpdateRequestModel
{
    public int InterviewFeedbackId { get; set; }
    [Required]
    [Range(1,5)]
    public Rating Rating { get; set; }
    [Required]
    [StringLength(2084)]
    public string? Comment { get; set; }
    public int InterviewId { get; set; }
}