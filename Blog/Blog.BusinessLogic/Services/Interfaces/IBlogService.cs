using Blog.Common.DTOs;

namespace Blog.BusinessLogic.Services.Interfaces
{
	public interface IBlogService
	{
		void AddRange();
		bool IsDelete(int id);
		IEnumerable<TopicDto> Get();
		TopicDto Get(int id);
	}
}

