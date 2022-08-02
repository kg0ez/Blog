using System;
namespace Blog.Model.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; } = null!;
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string Role { get; set; } = null!;

		//public string RefreshToken { get; set; }
		//public DateTime TokenCreated { get; set; }
		//public DateTime TokenExpires { get; set; }
		//Correspondent

		public IEnumerable<Topic> Topics { get; set; }

	}
}

