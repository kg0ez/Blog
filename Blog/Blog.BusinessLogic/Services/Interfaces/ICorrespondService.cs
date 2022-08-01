using Blog.Common.DTOs;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface ICorrespondService
	{
		bool IsRegister(BaseDto registerDto, RefreshTokenDto tokenDto);
		CorrespondentDto Login(BaseDto loginDto);
		void Update(Correspondent user, RefreshTokenDto tokenDto);
		Correspondent Get(string username);
		Correspondent Get(int id);
		IEnumerable<BaseDto> Get();
		bool IsDelete(int id);
	}
}

