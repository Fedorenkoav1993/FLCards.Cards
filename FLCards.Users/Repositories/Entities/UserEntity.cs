using System;

namespace FLCards.Users.Repositories.Entities
{
	public class UserEntity
	{
		public Guid Id { get; set; }

		public string Login { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string PasswordHash { get; set; }
	}
}
