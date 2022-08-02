using System;
using Blog.Common.DTOs;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	internal interface IInteractionDBService
	{
		User Get(string username);
		User UpdateDataToken(User user, RefreshTokenDto tokenDto);
		string SetREfToken(User user, RefreshTokenDto tokenDto);
	}
}

