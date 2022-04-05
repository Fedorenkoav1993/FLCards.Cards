using FLCards.Dictionary.ApplicationServices.Clients;
using FLCards.Dictionary.ApplicationServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FLCards.Cards.ApplicationServices.Configuration
{
	public static class ApplicationServicesServiceCollectionExtensions
	{
		public static IServiceCollection AddDictionaryApplicationServices(this IServiceCollection serviceCollection)
		{
			return serviceCollection
				.AddSingleton<IDictionaryService, DictionaryService>()
				.AddSingleton<ICambridgeDictionaryClient, CambridgeDictionaryClient>();
		}
	}
}
