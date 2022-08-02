using System;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Interfaces
{
	internal interface IInteractionDBService
	{
		User Get(string username);
	}
}

