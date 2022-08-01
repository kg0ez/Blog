using System;
namespace Blog.Model.Models
{
	public class Correspondent
	{
		public int Id { get; set; }
		public string Username { get; set; } = null!;
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }

		//public string RefreshToken { get; set; }
		//public DateTime TokenCreated { get; set; }
		//public DateTime TokenExpires { get; set; }

		public IEnumerable<Topic> Topics { get; set; }
	}
}

