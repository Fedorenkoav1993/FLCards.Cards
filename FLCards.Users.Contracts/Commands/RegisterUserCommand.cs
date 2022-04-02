namespace FLCards.Users.Contracts.Commands
{
	public sealed class RegisterUserCommand
	{
		public string Login { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Password { get; set; }
	}
}
