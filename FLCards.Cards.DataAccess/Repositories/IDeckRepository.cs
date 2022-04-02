using System;
using System.Threading.Tasks;
using FLCards.Cards.Domain.Model;

namespace FLCards.Cards.DataAccess.Repositories
{
	public interface IDeckRepository
	{
		Task<Deck> GetById(Guid deckId);

		Task Add(Deck deck);

		Task Update(Deck deck);

		Task Remove(Guid deckId);

		Task AddCard(Card card, Guid deckId);

		Task RemoveCard(Guid cardId);

		Task<Deck[]> GetDecks(Guid userId);

		Task<Card[]> GetCards(Guid deckId);
	}
}
