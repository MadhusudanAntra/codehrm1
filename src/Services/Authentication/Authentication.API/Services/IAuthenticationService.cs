using Authentication.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Services;

public interface IAuthenticationService<T>
{
    Task<bool> ValidateCredentials(T user, string password);

    Task<T> FindByUsername(string user);

    Task<T> FindByUserId(Guid userId);

    Task SignIn(T user);

    Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);

    Task<(IdentityResult identityResult, Guid userId)> CreateUserAsync(RegisterViewModel model);
}