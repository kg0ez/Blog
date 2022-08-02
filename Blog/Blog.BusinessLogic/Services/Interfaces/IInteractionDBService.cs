using System;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface IInteractionDBService
	{
		Correspondent Get(string username);
	}
}

