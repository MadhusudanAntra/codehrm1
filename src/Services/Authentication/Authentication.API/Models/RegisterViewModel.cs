using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; init; }

    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)] 
    public string LastName { get; set; }

}