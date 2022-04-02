using System.Threading.Tasks;
using FLCards.Cards.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;
using FLCards.Cards.Contracts.Commands;
using FLCards.Cards.Contracts.Queries;

namespace FLCards.Cards.Controllers
{
	[ApiController]
	public class DeckManagementController : ControllerBase
	{
		private IDeckService DeckService { get; }

		public DeckManagementController(
			IDeckService deckService)
		{
			DeckService = deckService;
		}

		[HttpPost]
		[Route("deck/add")]
		public async Task<ObjectResult> AddDeck(AddDeckCommand addDeckCommand)
		{
			var result = await DeckService.AddDeck(addDeckCommand);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}

		[HttpPost]
		[Route("deck/remove")]
		public async Task<ObjectResult> RemoveDeck(RemoveDeckCommand removeDeckCommand)
		{
			var result = await DeckService.RemoveDeck(removeDeckCommand);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}

		[HttpPost]
		[Route("deck/add-card")]
		public async Task<ObjectResult> AddCard(AddCardCommand addCardCommand)
		{
			var result = await DeckService.AddCard(addCardCommand);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}

		[HttpPost]
		[Route("deck/remove-card")]
		public async Task<ObjectResult> RemoveCard(RemoveCardCommand removeCardCommand)
		{
			var result = await DeckService.RemoveCard(removeCardCommand);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}

		[HttpPost]
		[Route("deck/get")]
		public async Task<ObjectResult> GetDecks(GetDecksQuery getDecksQuery)
		{
			var result = await DeckService.GetDecks(getDecksQuery);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}

		[HttpPost]
		[Route("deck/get-cards")]
		public async Task<ObjectResult> GetDecks(GetCardsQuery getCardsQuery)
		{
			var result = await DeckService.GetCards(getCardsQuery);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}
	}
}
