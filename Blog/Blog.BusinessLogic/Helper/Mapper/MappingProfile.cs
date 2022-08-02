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
			CreateMap<BaseDto, Correspondent>()
				.ForMember("Username", opt => opt.MapFrom(ud => ud.Username.ToLower()))
				.ForMember("PasswordHash", opt => opt.MapFrom(ud => hmac.ComputeHash(Encoding.UTF8.GetBytes(ud.Password))))
				.ForMember("PasswordSalt", opt => opt.MapFrom(ud => hmac.Key));
			CreateMap<Correspondent, ViewDto>()
				.ForMember("Name", opt => opt.MapFrom(opt =>opt.Id+" "+ opt.Username));
		}
	}
}

