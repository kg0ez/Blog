namespace Blog.Model.Models
{
	public class Topic
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string? Subtitle { get; set; }

		public int CorrespondentId { get; set; }
		public User Correspondent { get; set; } = null!;
	}
}

