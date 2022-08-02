using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IVerificationService _verification;
        private readonly IAuthService _auth;
        private readonly ITokenService _tokenService;

        public AuthController(IVerificationService verification,IAuthService authService,ITokenService tokenService)
        {
            _verification = verification;
            _auth = authService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto user)
        {
            if (_verification.IsExists(user.Username))
                return BadRequest("User with the same username is already registered");
            return _auth.IsCreate(user)? Ok("User was regisrered") : BadRequest("Failed to create account");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto user)
        {
            if (!_verification.IsExists(user.Username))
                return BadRequest("User not found");
            if (!_verification.IsVerifyPasswordHash(user))
                return BadRequest("Wrong password");

            string token = _tokenService.Create(user);

            return Ok(token);
        }
    }

}