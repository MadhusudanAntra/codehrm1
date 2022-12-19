using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Services;

public class AuthenticationService : IAuthenticationService<User>
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;


    public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> ValidateCredentials(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<User> FindByUsername(string user)
    {
        return await _userManager.FindByEmailAsync(user);
    }

    public async Task<User> FindByUserId(Guid userId)
    {
        return await _userManager.FindByIdAsync(userId.ToString());
    }

    public async Task SignIn(User user)
    {
        await _signInManager.SignInAsync(user, true);
    }

    public async Task SignInAsync(User user, AuthenticationProperties properties, string authenticationMethod = null)
    {
        await _signInManager.SignInAsync(user, properties, authenticationMethod);
    }

    public async Task<(IdentityResult identityResult, Guid userId)> CreateUserAsync(RegisterViewModel model)
    {
        var user = new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email
        };

       var result = await _userManager.CreateAsync(user, model.Password);
       return (result, user.Id);


    }
}