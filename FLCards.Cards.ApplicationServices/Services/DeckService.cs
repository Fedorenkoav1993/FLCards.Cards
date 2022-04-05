using System;
using System.Linq;
using System.Threading.Tasks;
using FLCards.Cards.Contracts.Commands;
using FLCards.Cards.Contracts.Data;
using FLCards.Cards.Contracts.Queries;
using FLCards.Cards.DataAccess.Repositories;
using FLCards.Cards.Domain.Model;
using FLCards.Common.Contracts;
using FLCards.Common.Infrastructure;

namespace FLCards.Cards.ApplicationServices.Services
{
	internal sealed class DeckService : IDeckService
	{
		public DeckService(IDeckRepository deckRepository)
		{
			DeckRepository = deckRepository;
		}

		private IDeckRepository DeckRepository { get; }

		public async Task<Result<AddDeckCommandResult, FailedResult>> AddDeck(AddDeckCommand addDeckCommand)
		{
			try
			{
				var deck = Deck.Create(addDeckCommand.UserId, addDeckCommand.Name);

				await DeckRepository.Add(deck);

				return new AddDeckCommandResult
				{
					DeckId = deck.Id
				};
			}
			catch (Exception e)
			{
				return new FailedResult
				{
					ErrorMessage = e.Message
				};
			}
		}

		public async Task<Result<RemoveDeckCommandResult, FailedResult>> RemoveDeck(RemoveDeckCommand removeDeckCommand)
		{
			try
			{
				await DeckRepository.Remove(removeDeckCommand.DeckId);

				return new RemoveDeckCommandResult();
			}
			catch (Exception e)
			{
				return new FailedResult
				{
					ErrorMessage = e.Message
				};
			}
		}

		public async Task<Result<AddCardCommandResult, FailedResult>> AddCard(AddCardCommand addCardCommand)
		{
			try
			{
				var card = Card.Create(
					new Phrase(addCardCommand.Phrase.Value, addCardCommand.Phrase.Language),
					new Phrase(addCardCommand.Translation.Value, addCardCommand.Translation.Language),
					!string.IsNullOrWhiteSpace(addCardCommand.ImageUrl)
						? new Uri(addCardCommand.ImageUrl)
						: null);

				await DeckRepository.AddCard(card, addCardCommand.DeckId);

				return new AddCardCommandResult();
			}
			catch (Exception e)
			{
				return new FailedResult
				{
					ErrorMessage = e.Message
				};
			}
		}

		public async Task<Result<RemoveCardCommandResult, FailedResult>> RemoveCard(RemoveCardCommand removeCardCommand)
		{
			try
			{
				await DeckRepository.RemoveCard(removeCardCommand.CardId);

				return new RemoveCardCommandResult();
			}
			catch (Exception e)
			{
				return new FailedResult
				{
					ErrorMessage = e.Message
				};
			}
		}

		public async Task<Result<GetDecksQueryResult, FailedResult>> GetDecks(GetDecksQuery getDecksQuery)
		{
			try
			{
				var decks = (await DeckRepository.GetDecks(getDecksQuery.UserId))
					.Select(d => new DeckDto
					{
						Id = d.Id,
						Name = d.Name
					}).ToArray();

				return new GetDecksQueryResult
				{
					Decks = decks
				};
			}
			catch (Exception e)
			{
				return new FailedResult
				{
					ErrorMessage = e.Message
				};
			}
		}

		public async Task<Result<GetCardsQueryResult, FailedResult>> GetCards(GetCardsQuery getDecksQuery)
		{
			try
			{
				var cards = (await DeckRepository.GetCards(getDecksQuery.DeckId))
					.Select(c => new CardDto
					{
						Id = c.Id,
						Original = new PhraseDto
						{
							Value = c.Original.Value,
							Language = c.Original.Language
						},
						Translation = new PhraseDto
						{
							Value = c.Translation.Value,
							Language = c.Translation.Language
						},
						ImageUri = c.ImageUri?.AbsoluteUri
					}).ToArray();

				return new GetCardsQueryResult
				{
					Cards = cards
				};
			}
			catch (Exception e)
			{
				return new FailedResult
				{
					ErrorMessage = e.Message
				};
			}
		}
	}
}
