using Blog.Common.DTOs;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	internal interface IInteractionDBService
	{
		User Get(string username);
		User Get(int id);
		User UpdateDataToken(User user, RefreshTokenDto tokenDto);
		string SetREfToken(User user, RefreshTokenDto tokenDto);
	}
}

