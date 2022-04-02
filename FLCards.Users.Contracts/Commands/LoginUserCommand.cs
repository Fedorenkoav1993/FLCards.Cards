namespace FLCards.Users.Contracts.Commands
{
	public sealed class LoginUserCommand
	{
		public string Login { get; set; }

		public string Password { get; set; }
	}
}
