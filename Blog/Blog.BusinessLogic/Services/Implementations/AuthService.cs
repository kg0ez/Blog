using System;
using AutoMapper;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;
using Blog.Model.Models;

namespace Blog.BusinessLogic.Services.Implementations
{
	public class AuthService: IAuthService
	{
        private readonly IMapper _mapper;
        private readonly ApplicationContext _db;
		public AuthService(IMapper mapper, ApplicationContext context)
		{
            _mapper = mapper;
            _db = context;
		}

        public bool IsCreate(BaseDto user)
        {
            var correspond = _mapper.Map<Correspondent>(user);
            _db.Correspondents.Add(correspond);
            return Save();
        }

        private bool Save()=>
            _db.SaveChanges() > 0 ? true : false;
    }
}

