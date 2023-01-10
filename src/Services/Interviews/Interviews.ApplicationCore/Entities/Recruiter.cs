using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.ApplicationCore.Entities;

public class Recruiter
{
    public int RecruiterId { get; set; }
    public string? FirstName { get; set; } //should I set it as Nullable when it's required on db?
    public string? LastName { get; set; }
    public int EmployeeId { get; set; }
}