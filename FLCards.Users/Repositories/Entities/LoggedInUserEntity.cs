using System;

namespace FLCards.Users.Repositories.Entities
{
	public class LoggedInUserEntity
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public string SessionToken { get; set; }
	}
}
