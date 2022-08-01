using System;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;
using Blog.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.BusinessLogic.Services.Implementations
{
	public class CorrespondService: ICorrespondService
	{
        private readonly ApplicationContext _db;

		public CorrespondService(ApplicationContext context)
		{
            _db = context;
		}

        public bool IsDelete(int id)
        {
            var coresp = _db.Correspondents.FirstOrDefault(x => x.Id == id);
            if (coresp == null)
                return false;
            _db.Correspondents.Remove(coresp);
            return Save();
        }

        private bool Save() =>
            _db.SaveChanges() > 0 ? true : false;

        public Correspondent Get(string username)
        {
            throw new NotImplementedException();
        }

        public Correspondent Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseDto> Get()
        {
            throw new NotImplementedException();
        }

        public CorrespondentDto Login(BaseDto loginDto)
        {
            throw new NotImplementedException();
        }

        public bool IsRegister(BaseDto registerDto, RefreshTokenDto tokenDto)
        {
            throw new NotImplementedException();
        }

        public void Update(Correspondent user, RefreshTokenDto tokenDto)
        {
            throw new NotImplementedException();
        }
    }
}

