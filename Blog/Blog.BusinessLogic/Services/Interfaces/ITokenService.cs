using System;
using Blog.Common.DTOs;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface ITokenService
	{
		string Create(LoginDto dto);
	}
}

