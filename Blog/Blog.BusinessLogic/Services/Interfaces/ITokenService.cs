using Blog.Common.DTOs;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface ITokenService
	{
		string Create(LoginDto dto);
		string Create(int id);
		RefreshTokenDto GenerateRefreshToken();
		bool IsVerifyRefTokon(int id, string refreshToken);
		bool IsExpires(int id);
		string RefreshToken(int id, RefreshTokenDto tokenDto);
	}
}

