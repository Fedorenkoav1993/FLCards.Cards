using System;

namespace FLCards.Cards.Contracts.Queries
{
	public sealed class GetCardsQuery
	{
		public Guid DeckId { get; set; }
	}
}
