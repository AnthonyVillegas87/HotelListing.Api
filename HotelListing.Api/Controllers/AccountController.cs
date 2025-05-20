using HotelListing.Api.Contracts;
using HotelListing.Api.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthManager authManager, ILogger<AccountController> logger)
        {
            _authManager = authManager;
            _logger = logger;
        }
        
        // POST: api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody]ApiUserDto apiUserDto)
        {
            _logger.LogInformation($"Registering user for {apiUserDto.Email}");
            try
            {
                var errors = await _authManager.Register(apiUserDto);
                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }
                return Ok(apiUserDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error registering user for {nameof(Register)} - User Registration attempt for {apiUserDto.Email} failed.");
                return Problem($"Something went wrong in the {nameof(Register)}. Please contact support", statusCode: 500);
            }
            
        }
        
        
        
        // POST: api/Account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody]LoginDto loginDto)
        {
            _logger.LogInformation($"Logging in user for {loginDto.Email}");
            try
            {
                var authResponse = await _authManager.Login(loginDto);
                if (authResponse == null)
                {
                    return Unauthorized();
                }
                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error logging in user for {nameof(Login)} - User Login attempt for {loginDto.Email} failed.");
               return Problem($"Something went wrong in the {nameof(Login)}. Please contact support", statusCode: 500);
            }
          
        }
        
        // POST: api/Account/refresh-token
        [HttpPost]
        [Route("refresh-token")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody]AuthResponseDto request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);
            if (authResponse is null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
    }
}
