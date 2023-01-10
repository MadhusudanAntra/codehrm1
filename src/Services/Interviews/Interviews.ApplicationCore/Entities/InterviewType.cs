using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.ApplicationCore.Entities;

public class InterviewType
{
    public int LookupCode { get; set; }
    public string? InterviewTypeName { get; set; }
}