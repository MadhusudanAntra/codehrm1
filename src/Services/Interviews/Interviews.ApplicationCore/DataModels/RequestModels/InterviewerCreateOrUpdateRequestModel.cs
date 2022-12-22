using System.ComponentModel.DataAnnotations;

namespace Interviews.ApplicationCore.DataModels.RequestModels;

public class InterviewerCreateOrUpdateRequestModel
{
    public int InterviewerId { get; set; }
    [Required]
    [MaxLength(128)]
    public string? FirstName { get; set; } 
    [Required]
    [MaxLength(128)]
    public string? LastName { get; set; }
    public int EmployeeId { get; set; }
}