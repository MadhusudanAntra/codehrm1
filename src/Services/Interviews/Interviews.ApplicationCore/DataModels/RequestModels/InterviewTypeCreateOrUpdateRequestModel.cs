using System.ComponentModel.DataAnnotations;

namespace Interviews.ApplicationCore.DataModels.RequestModels;

public class InterviewTypeCreateOrUpdateRequestModel
{
    public int LookupCode { get; set; }
    [Required]
    [StringLength(2084)]
    public string? InterviewTypeName { get; set; }
}