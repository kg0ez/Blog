using System.Security.Cryptography;
using System.Text;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;

namespace Blog.BusinessLogic.Services.Implementations
{
	public class VerificationService: IVerificationService
	{
        private readonly ApplicationContext _db;
        private readonly IInteractionDBService _dBService;

		public VerificationService(ApplicationContext context)
		{
            _db = context;
            _dBService = new InteractionDBService(context);
		}

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool IsVerifyPasswordHash(LoginDto user)
        {
            var correspond = _dBService.Get(user.Username)!;
            using (var hmac = new HMACSHA256(correspond.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                return computedHash.SequenceEqual(correspond.PasswordHash);
            }
        }
        
        public bool IsExists(string username)=>
            _db.Users.Any(c => c.Username == username);

        public bool IsExists(int id)=>
            _db.Users.Any(c => c.Id == id);

        
    }
}

