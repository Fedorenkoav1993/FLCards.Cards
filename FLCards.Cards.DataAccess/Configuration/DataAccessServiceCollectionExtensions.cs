using FLCards.Cards.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FLCards.Cards.DataAccess.Configuration
{
	public static class DataAccessServiceCollectionExtensions
	{
		public static IServiceCollection AddDataAccessService(this IServiceCollection serviceCollection)
		{
			return serviceCollection.AddSingleton<IDeckRepository, DeckRepository>();
		}
	}
}
