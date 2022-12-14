using Authentication.API.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Services;

public class AuthenticationService:IAuthenticationService<User>
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;


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

    public async Task SignIn(User user)
    {
        await _signInManager.SignInAsync(user, true);
    }

    public async Task SignInAsync(User user, AuthenticationProperties properties, string authenticationMethod = null)
    {
        await _signInManager.SignInAsync(user, properties, authenticationMethod);
    }
}