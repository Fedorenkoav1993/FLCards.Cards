using FLCards.Cards.Contracts.Data;

namespace FLCards.Cards.Contracts.Queries
{
	public sealed class GetDecksQueryResult
	{
		public DeckDto[] Decks { get; set; }
	}
}
