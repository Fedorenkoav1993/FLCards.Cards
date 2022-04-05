using System.Threading.Tasks;
using FLCards.Cards.Contracts.Commands;
using FLCards.Cards.Contracts.Queries;
using FLCards.Common.Contracts;
using FLCards.Common.Infrastructure;

namespace FLCards.Cards.ApplicationServices.Services
{
	public interface IDeckService
	{
		Task<Result<AddDeckCommandResult, FailedResult>> AddDeck(AddDeckCommand addDeckCommand);

		Task<Result<RemoveDeckCommandResult, FailedResult>> RemoveDeck(RemoveDeckCommand removeDeckCommand);

		Task<Result<AddCardCommandResult, FailedResult>> AddCard(AddCardCommand addCardCommand);

		Task<Result<RemoveCardCommandResult, FailedResult>> RemoveCard(RemoveCardCommand removeCardCommand);
		
		Task<Result<GetCardsQueryResult, FailedResult>> GetCards(GetCardsQuery getDecksQuery);

		Task<Result<GetDecksQueryResult, FailedResult>> GetDecks(GetDecksQuery getDecksQuery);
	}
}
