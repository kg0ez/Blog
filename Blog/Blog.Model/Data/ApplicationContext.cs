using System;
using Blog.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Model.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Correspondent> Correspondents { get; set; } = null!;
		public DbSet<Topic> Topics { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Topic>()
				.HasOne(t => t.Correspondent)
				.WithMany(c => c.Topics)
				.OnDelete(DeleteBehavior.Cascade);
        }
	}
}

