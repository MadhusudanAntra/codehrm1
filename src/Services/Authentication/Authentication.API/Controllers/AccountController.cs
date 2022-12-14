using Authentication.API.Entities;
using Authentication.API.Models;
using Authentication.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService<User> _authenticationService;
        private readonly AppSettings _appSettings;

        public AccountController(IAuthenticationService<User> authenticationService, IOptions<AppSettings> appSettings)
        {
            _authenticationService = authenticationService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var test = _appSettings.Secret;
            if (!ModelState.IsValid) return BadRequest(new {error = "Please check email/password format"});
            var user = await _authenticationService.FindByUsername(model.Email);
            if (await _authenticationService.ValidateCredentials(user, model.Password))
            {
                // create JWT
            }

            return BadRequest(new { error = "No User found" });

        }

        private string GenerateJwt(User user)
        {
            return "xXcdscd";
        }
    }
}
