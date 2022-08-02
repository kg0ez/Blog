using Blog.Common.DTOs;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface ICorrespondService
	{
		void Update(Correspondent user, RefreshTokenDto tokenDto);
		ViewDto Get(string username);
		ViewDto Get(int id);
		IEnumerable<ViewDto> Get();
		bool IsDelete(int id);
	}
}

