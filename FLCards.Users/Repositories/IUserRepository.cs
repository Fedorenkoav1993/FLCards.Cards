using System;
using System.Threading.Tasks;
using FLCards.Users.Domain;

namespace FLCards.Users.Repositories
{
	public interface IUserRepository
	{
		Task Add(User user);

		Task AddLoggedInUser(Guid userId, string sessionToken);

		Task RemoveLoggedInUser(string sessionToken);

		Task<Guid?> FindId(string login, string passwordHash);
	}
}
