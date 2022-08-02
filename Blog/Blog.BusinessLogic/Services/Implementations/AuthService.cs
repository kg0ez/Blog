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
        private readonly IInteractionDBService _dBService;

		public AuthService(IMapper mapper, ApplicationContext context)
		{
            _mapper = mapper;
            _db = context;
            _dBService = new InteractionDBService(context);
		}

        //public bool IsCreate(RegisterDto user)
        //{
        //    var correspond = _mapper.Map<User>(user);
        //    _db.Users.Add(correspond);
        //    return Save();
        //}
        public bool IsRegister(RegisterDto dto, RefreshTokenDto tokenDto)
        {
            var user = _mapper.Map<User>(dto);
            user = _dBService.UpdateDataToken(user, tokenDto);
            _db.Users.Add(user);
            return _db.SaveChanges() > 0 ? true : false;
        }
        public string Login(LoginDto dto, RefreshTokenDto tokenDto)
        {
            var user = _dBService.Get(dto.Username);
            return _dBService.SetREfToken(user, tokenDto);
            //_db.Users.Update(_dBService.UpdateDataToken(user, tokenDto));
            //return Save()? Environment.NewLine + "RefreshToken: " + user.RefreshToken :
            //    "RefreshToken was not created";
        }
        
    }
}

