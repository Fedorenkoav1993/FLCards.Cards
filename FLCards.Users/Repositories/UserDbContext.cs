using FLCards.Users.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace FLCards.Users.Repositories
{
	public class UserDbContext : DbContext
	{
		public virtual DbSet<UserEntity> Users { get; set; }
		public virtual DbSet<LoggedInUserEntity> LoggedInUsers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FLCards_Users;Trusted_Connection=True;");
		}
	}
}
