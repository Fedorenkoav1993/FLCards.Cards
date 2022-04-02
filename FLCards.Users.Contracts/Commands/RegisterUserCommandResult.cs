namespace FLCards.Users.Contracts.Commands
{
	public sealed class RegisterUserCommandResult
	{
		public bool IsRegistered { get; set; }

		public bool IsLoggedIn { get; set; }

		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }
	}
}
