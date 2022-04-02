using System;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FLCards.Users.Contracts.Commands;
using FLCards.Users.Domain;
using FLCards.Users.Repositories;

namespace FLCards.Users.Services
{
	public class UserService : IUserService
	{
		public UserService(IUserRepository userRepository)
		{
			UserRepository = userRepository;
		}

		private IUserRepository UserRepository { get; }

		public async Task<RegisterUserCommandResult> RegisterUser(RegisterUserCommand registerUserCommand)
		{
			try
			{
				var user = new User(
					registerUserCommand.Login,
					registerUserCommand.Name,
					registerUserCommand.Email,
					registerUserCommand.Phone,
					GetPasswordHash(registerUserCommand.Password));

				await UserRepository.Add(user);

				return new RegisterUserCommandResult
				{
					IsRegistered = true,
					IsLoggedIn = true,
				};
			}
			catch (Exception e)
			{
				return new RegisterUserCommandResult
				{
					IsRegistered = false,
					IsLoggedIn = false,
					ErrorMessage = e.Message
				};
			}
		}

		public async Task<LoginUserCommandResult> LoginUser(LoginUserCommand loginUserCommand)
		{
			try
			{
				var passwordHash = GetPasswordHash(loginUserCommand.Password);

				var userId = await UserRepository.FindId(loginUserCommand.Login, passwordHash);

				if (!userId.HasValue)
				{
					return new LoginUserCommandResult
					{
						IsLoggedIn = false
					};
				}

				var sessionToken = Guid.NewGuid().ToString(); //TODO: replace with jwt

				await UserRepository.AddLoggedInUser(userId.Value, sessionToken);

				return new LoginUserCommandResult
				{
					IsLoggedIn = true,
					SessionToken = sessionToken
				};
			}
			catch (Exception e)
			{
				return new LoginUserCommandResult
				{
					IsLoggedIn = false
				};
			}
		}

		public async Task<LogoutUserCommandResult> LogoutUser(LogoutUserCommand logoutUserCommand)
		{
			try
			{
				await UserRepository.RemoveLoggedInUser(logoutUserCommand.SessionToken);

				return new LogoutUserCommandResult
				{
					IsLoggedOut = true
				};
			}
			catch (Exception e)
			{
				return new LogoutUserCommandResult
				{
					IsLoggedOut = false
				};
			}
		}

		private string GetPasswordHash(string password)
		{
			var passwordBytes = Encoding.UTF8.GetBytes(password);

			var sha256 = SHA256.Create();

			return Convert.ToBase64String(sha256.ComputeHash(passwordBytes));
		}
	}
}
