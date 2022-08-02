using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;
using Blog.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.BusinessLogic.Services.Implementations
{
	internal class InteractionDBService: IInteractionDBService
	{
		private readonly ApplicationContext _db;

		internal InteractionDBService(ApplicationContext context)
		{
			_db = context;
		}

		public User Get(string username)=>
			_db.Users.AsNoTracking().FirstOrDefault(c => c.Username == username)!;

		public User Get(int id)=>
			_db.Users.AsNoTracking().FirstOrDefault(c => c.Id == id)!;

		public User UpdateDataToken(User user, RefreshTokenDto tokenDto)
		{
			user.TokenCreated = tokenDto.Created;
			user.TokenExpires = tokenDto.Expires;
			user.RefreshToken = tokenDto.Token;
			return user;
		}
		public string SetREfToken(User user, RefreshTokenDto tokenDto)
        {
			_db.Users.Update(UpdateDataToken(user, tokenDto));
			return Save() ? Environment.NewLine + "RefreshToken: " + user.RefreshToken :
				"RefreshToken was not created";
		}
		private bool Save() =>
			_db.SaveChanges() > 0 ? true : false;
	}
}

