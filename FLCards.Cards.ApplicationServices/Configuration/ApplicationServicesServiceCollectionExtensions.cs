using FLCards.Cards.ApplicationServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FLCards.Cards.ApplicationServices.Configuration
{
	public static class ApplicationServicesServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
		{
			return serviceCollection
				.AddSingleton<IDeckService, DeckService>()
				.AddSingleton<ILearningService, LearningService>();
		}
	}
}
