using System;
using System.Linq;
using System.Threading.Tasks;
using FLCards.Users.Domain;
using FLCards.Users.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace FLCards.Users.Repositories
{
	public class UserRepository : IUserRepository
	{
		public async Task Add(User user)
		{
			using (var context = new UserDbContext())
			{
				context.Users.Add(ConvertToUserEntity(user));
				await context.SaveChangesAsync();
			}
		}

		public async Task AddLoggedInUser(Guid userId, string sessionToken)
		{
			using (var context = new UserDbContext())
			{
				context.LoggedInUsers.Add(new LoggedInUserEntity
				{
					Id = Guid.NewGuid(),
					UserId = userId,
					SessionToken = sessionToken
				});

				await context.SaveChangesAsync();
			}
		}

		public async Task RemoveLoggedInUser(string sessionToken)
		{
			using (var context = new UserDbContext())
			{
				var loggedInUser = await context.LoggedInUsers
					.FirstOrDefaultAsync(u => u.SessionToken == sessionToken);

				if (loggedInUser == null)
				{
					return;
				}

				context.LoggedInUsers.Remove(loggedInUser);

				await context.SaveChangesAsync();
			}
		}

		public async Task<Guid?> FindId(string login, string passwordHash)
		{
			using (var context = new UserDbContext())
			{
				var userIds = await context.Users.Where(u =>(u.Email == login || u.Login == login || u.Phone == login) && u.PasswordHash == passwordHash)
					.Select(u => u.Id)
					.ToArrayAsync();

				if (userIds.Length != 1)
				{
					return null;
				}

				return userIds[0];
			}
		}

		private UserEntity ConvertToUserEntity(User user)
		{
			return new UserEntity
			{
				Id = user.Id,
				Login = user.Login,
				Email = user.Email,
				Name = user.Name,
				Phone = user.Phone,
				PasswordHash = user.PasswordHash
			};
		}
	}
}
