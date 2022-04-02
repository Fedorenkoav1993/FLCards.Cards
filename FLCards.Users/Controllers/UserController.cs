using System;
using System.Threading.Tasks;
using FLCards.Users.Contracts.Commands;
using FLCards.Users.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FLCards.Users.Controllers
{
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;

		public UserController(
			IUserService userService,
			ILogger<UserController> logger)
		{
			_logger = logger;

			UserService = userService;
		}

		private IUserService UserService { get; }

		[HttpPost]
		[Route("user/register")]
		public Task<RegisterUserCommandResult> RegisterUser(RegisterUserCommand registerUserCommand)
		{
			if (registerUserCommand == null)
			{
				throw new Exception($"Command {nameof(registerUserCommand)} cannot be null");
			}

			return UserService.RegisterUser(registerUserCommand);
		}

		[HttpPost]
		[Route("user/login")]
		public Task<LoginUserCommandResult> LoginUser(LoginUserCommand loginUserCommand)
		{
			if (loginUserCommand == null)
			{
				throw new Exception($"Command {nameof(loginUserCommand)} cannot be null");
			}

			return UserService.LoginUser(loginUserCommand);
		}

		[HttpPost]
		[Route("user/logout")]
		public Task<LogoutUserCommandResult> LogoutUser(LogoutUserCommand logoutUserCommand)
		{
			if (logoutUserCommand == null)
			{
				throw new Exception($"Command {nameof(logoutUserCommand)} cannot be null");
			}

			return UserService.LogoutUser(logoutUserCommand);
		}
	}
}
