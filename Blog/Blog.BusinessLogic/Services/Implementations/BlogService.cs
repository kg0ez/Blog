using AutoMapper;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Blog.Model.Data;
using Blog.Model.Models;
using Blog.Parser;
using Microsoft.EntityFrameworkCore;

namespace Blog.BusinessLogic.Services.Implementations
{
	public class BlogService: IBlogService
	{
		private readonly ApplicationContext _db;
		private readonly NewsParser _parser;
		private readonly IMapper _mapper;

		public BlogService(ApplicationContext context, IMapper mapper)
		{
			_db = context;
			_parser = new NewsParser();
			_mapper = mapper;
		}

		private void Delete()
        {
			_db.Topics.RemoveRange();
        }
		public void AddRange()
        {
			Delete();
			var user = _db.Users.FirstOrDefault(u => u.Id == 1);
			List<Topic> topics = _mapper.Map<List<Topic>>(_parser.Parser());
            foreach (var item in topics)
            {
				item.CorrespondentId = 1;
				item.Correspondent = user!;
            }
			_db.Topics.AddRange(topics);
			_db.SaveChanges();
        }
		public bool IsDelete(int id)
		{
			var topics = _db.Topics.FirstOrDefault(x => x.Id == id);
			if (topics == null)
				return false;
			_db.Topics.Remove(topics);
			return _db.SaveChanges() > 0 ? true : false;
		}
		public IEnumerable<TopicDto> Get() =>
              _mapper.Map<List<TopicDto>>(_db.Topics.AsNoTracking().ToList());

		public TopicDto Get(int id) =>
			  _mapper.Map<TopicDto>(_db.Topics.AsNoTracking().FirstOrDefault(c => c.Id == id));
	}
}

