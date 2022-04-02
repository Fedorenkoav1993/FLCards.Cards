namespace FLCards.Users.Contracts.Commands
{
	public sealed class LoginUserCommandResult
	{
		public bool IsLoggedIn { get; set; }

		public string SessionToken { get; set; }
	}
}
