using System;
using Blog.Common.DTOs;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface IVerificationService
	{
		bool IsExists(string username);
		void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
		bool IsVerifyPasswordHash(BaseDto user);
		//bool IsVerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
	}
}

