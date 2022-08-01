using System;
using System.Security.Cryptography;
using System.Text;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.BusinessLogic.Services.Implementations
{
	public class VerificationService: IVerificationService
	{
        private readonly ApplicationContext _db;

		public VerificationService(ApplicationContext context)
		{
            _db = context;
		}

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //public bool IsVerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA256(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return computedHash.SequenceEqual(passwordHash);
        //    }
        //}
        public bool IsVerifyPasswordHash(BaseDto user)
        {
            var correspond = _db.Correspondents.AsNoTracking().FirstOrDefault(c => c.Username == user.Username)!;
            using (var hmac = new HMACSHA256(correspond.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                return computedHash.SequenceEqual(correspond.PasswordHash);
            }
        }

        public bool IsExists(string username)=>
            _db.Correspondents.Any(c => c.Username == username);
    }
}

