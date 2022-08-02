﻿using System;
using Blog.BusinessLogic.Services.Interfaces;
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

		public Correspondent Get(string username)=>
			_db.Correspondents.AsNoTracking().FirstOrDefault(c => c.Username == username)!;
	}
}
