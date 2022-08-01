using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.BusinessLogic.Services.Implementations;
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
        public IActionResult Register(BaseDto user)
        {
            if (_verification.IsExists(user.Username))
                return BadRequest("Correspondent with the same username is already registered");
            _auth.IsCreate(user);

            return Ok("Correspondent was regisrered");
        }

        [HttpPost("login")]
        public IActionResult Login(BaseDto user)
        {
            if (!_verification.IsExists(user.Username))
                return BadRequest("Correspondent not found");
            if (!_verification.IsVerifyPasswordHash(user))
                return BadRequest("Wrong password");

            string token = _tokenService.CreateToken(user);

            return Ok("sex");
        }
    }

}