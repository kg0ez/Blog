using System;
using System.Text;
using AutoMapper;
using Blog.Common.DTOs;
using Blog.Model.Models;
using System.Security.Cryptography;

namespace Blog.BusinessLogic.Helper.Mapper
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
			var hmac = new HMACSHA256();

            CreateMap<Topic, TopicDto>().ReverseMap();
			CreateMap<RegisterDto, User>()
				.ForMember("Username", opt => opt.MapFrom(opt => opt.Username.ToLower()))
				.ForMember("PasswordHash", opt => opt.MapFrom(opt => hmac.ComputeHash(Encoding.UTF8.GetBytes(opt.Password))))
				.ForMember("PasswordSalt", opt => opt.MapFrom(opt => hmac.Key))
				.ForMember("Role", opt => opt.MapFrom(opt => opt.Role.ToLower()));
			CreateMap<User, ViewDto>()
				.ForMember("Name", opt => opt.MapFrom(opt =>opt.Id+" "+ opt.Username));
		}
	}
}

