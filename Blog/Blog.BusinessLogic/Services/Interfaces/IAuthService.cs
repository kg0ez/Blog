using Blog.Common.DTOs;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface IAuthService
	{
		bool IsRegister(RegisterDto dto, RefreshTokenDto tokenDto);
		string Login(LoginDto dto, RefreshTokenDto tokenDto);
	}
}

