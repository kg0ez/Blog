using Blog.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IVerificationService _verification;
        private readonly ITokenService _token;

        public TokenController(IVerificationService verification, ITokenService token)
        {
            _verification = verification;
            _token = token;
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromQuery] int id, [FromQuery] string refreshToken)
        {
            if (!_verification.IsExists(id))
                return BadRequest("User is not found");

            if (!_token.IsVerifyRefTokon(id,refreshToken))
                return Unauthorized("Invalid Refresh Token");
            else if(_token.IsExpires(id))
                return Unauthorized("Token expired");

            string token = _token.Create(id);

            var refresh = _token.GenerateRefreshToken();
            return Ok("Token: " + token + _token.RefreshToken(id, refresh));
        }
    }
}

