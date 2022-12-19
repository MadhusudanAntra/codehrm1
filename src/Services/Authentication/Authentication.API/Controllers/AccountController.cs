using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.API.Entities;
using Authentication.API.Models;
using Authentication.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

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

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new {error = "Please check email/password format"});
            var user = await _authenticationService.FindByUsername(model.Email);
            if (await _authenticationService.ValidateCredentials(user, model.Password))
            {
                return Ok( GenerateJwt(user));
            }

            return BadRequest(new { error = "No User found" });

        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegisterUserAsync(
            [FromBody] RegisterViewModel model)
        {

            var createdUser = await _authenticationService.CreateUserAsync(model);
         
            return CreatedAtRoute("GetUser", new { controller = "account", id = createdUser },
                $"User {createdUser} is created");
           
        }
        
        [HttpGet("{id:guid}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserViewModel>> GetUserByIdAsync(Guid id)
        {
            var user = await _authenticationService.FindByUserId(id);
            return Ok(user);
        }


        private string GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new []
                {
                    new Claim( JwtRegisteredClaimNames.Email, user.Email ),
                    new Claim( JwtRegisteredClaimNames.NameId, user.Id.ToString() ),
                    new Claim( JwtRegisteredClaimNames.FamilyName, user.LastName ),
                    new Claim( JwtRegisteredClaimNames.GivenName, user.FirstName ),
                } ),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
