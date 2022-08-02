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
        private readonly ApplicationContext _db;

        public TokenService(ApplicationContext context, IConfiguration config)
        {
            _dBService = new InteractionDBService(context);
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _db = context;
        }

        public string Create(LoginDto dto)
        {
            var user = _dBService.Get(dto.Username);
            return Token(user);
        }
        public string Create(int id)
        {
            var user = _db.Users.FirstOrDefault(u=>u.Id ==id)!;
            return Token(user);
        }

        private string Token(User user)
        {
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

        public RefreshTokenDto GenerateRefreshToken()
        {
            var refreshToken = new RefreshTokenDto
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        public bool IsVerifyRefTokon(int id, string refreshToken) =>
            _db.Users.FirstOrDefault(u => u.Id == id)!.RefreshToken.Equals(refreshToken);

        public bool IsExpires(int id) =>
            _db.Users.FirstOrDefault(u => u.Id == id)!.TokenExpires < DateTime.Now;

        public string RefreshToken(int id, RefreshTokenDto tokenDto)=>
            _dBService.SetREfToken(_db.Users.FirstOrDefault(u => u.Id == id)!, tokenDto);
    }
}

