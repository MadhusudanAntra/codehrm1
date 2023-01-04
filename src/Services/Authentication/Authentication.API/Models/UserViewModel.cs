namespace Authentication.API.Models;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string Email { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}