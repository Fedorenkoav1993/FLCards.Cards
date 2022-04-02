using System;

namespace FLCards.Users.Domain
{
	public sealed class User
	{
		public User(string login, string name, string email, string phone, string passwordHash)
		{
			Id = Guid.NewGuid();
			Login = login;
			Name = name;
			Email = email;
			Phone = phone;
			PasswordHash = passwordHash;
		}

		public Guid Id { get; }

		public string Login { get; }

		public string Name { get; }

		public string Email { get; }

		public string Phone { get; }

		public string PasswordHash { get; }
	}
}
