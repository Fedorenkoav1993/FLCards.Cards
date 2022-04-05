using FLCards.Dictionary.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FLCards.Cards.DataAccess.Configuration
{
	public static class DataAccessServiceCollectionExtensions
	{
		public static IServiceCollection AddDictionaryDataAccessService(this IServiceCollection serviceCollection)
		{
			return serviceCollection.AddSingleton<IDictionaryRepository, DictionaryRepository>();
		}
	}
}
