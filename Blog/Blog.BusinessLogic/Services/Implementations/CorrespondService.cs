using System;
using AutoMapper;
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
        private readonly IMapper _mapper;

		public CorrespondService(ApplicationContext context,IMapper mapper)
		{
            _db = context;
            _mapper = mapper;
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

        public ViewDto Get(string username)=>
            _mapper.Map<ViewDto>(_db.Correspondents.AsNoTracking().FirstOrDefault(c => c.Username == username));

        public ViewDto Get(int id)=>
            _mapper.Map<ViewDto>(_db.Correspondents.AsNoTracking().FirstOrDefault(c => c.Id == id));

        public IEnumerable<ViewDto> Get()=>
            _mapper.Map<List<ViewDto>>(_db.Correspondents.AsNoTracking().ToList());

        public void Update(Correspondent user, RefreshTokenDto tokenDto)
        {
            throw new NotImplementedException();
        }
    }
}

