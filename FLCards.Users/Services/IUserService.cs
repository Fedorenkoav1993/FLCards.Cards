using System.Threading.Tasks;
using FLCards.Users.Contracts.Commands;

namespace FLCards.Users.Services
{
	public interface IUserService
	{
		Task<RegisterUserCommandResult> RegisterUser(RegisterUserCommand registerUserCommand);

		Task<LoginUserCommandResult> LoginUser(LoginUserCommand loginUserCommand);

		Task<LogoutUserCommandResult> LogoutUser(LogoutUserCommand logoutUserCommand);
	}
}
