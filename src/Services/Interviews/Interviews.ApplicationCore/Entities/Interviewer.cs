using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.ApplicationCore.Entities;

public class Interviewer
{
    public int InterviewerId { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public int EmployeeId { get; set; }
}