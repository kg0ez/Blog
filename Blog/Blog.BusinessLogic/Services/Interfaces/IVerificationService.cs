using Blog.Common.DTOs;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface IVerificationService
	{
		bool IsExists(string username);
		bool IsExists(int id);
		void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
		bool IsVerifyPasswordHash(LoginDto user);
	}
}

