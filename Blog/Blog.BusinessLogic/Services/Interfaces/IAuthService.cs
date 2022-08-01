using System;
using Blog.Common.DTOs;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface IAuthService
	{
		bool IsCreate(BaseDto user);
	}
}

