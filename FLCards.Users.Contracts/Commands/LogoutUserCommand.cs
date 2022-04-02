namespace FLCards.Users.Contracts.Commands
{
	public sealed class LogoutUserCommand
	{
		public string SessionToken { get; set; }
	}
}
