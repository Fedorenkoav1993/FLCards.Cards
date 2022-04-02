using FLCards.Cards.Contracts.Data;

namespace FLCards.Cards.Contracts.Queries
{
	public sealed class GetCardsQueryResult
	{
		public CardDto[] Cards { get; set; }
	}
}
