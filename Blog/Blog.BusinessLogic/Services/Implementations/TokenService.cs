using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;
using Blog.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blog.BusinessLogic.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IInteractionDBService _dBService;
        private readonly SymmetricSecurityKey _key;

        public TokenService(ApplicationContext context, IConfiguration config)
        {
            _dBService = new InteractionDBService(context);
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string Create(LoginDto dto)
        {
            var user = _dBService.Get(dto.Username);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

