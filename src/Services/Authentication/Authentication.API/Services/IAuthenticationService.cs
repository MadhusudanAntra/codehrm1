using Microsoft.AspNetCore.Authentication;

namespace Authentication.API.Services;

public interface IAuthenticationService<T>
{
    Task<bool> ValidateCredentials(T user, string password);

    Task<T> FindByUsername(string user);

    Task SignIn(T user);

    Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
}