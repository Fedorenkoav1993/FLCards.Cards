using System;

namespace FLCards.Cards.Contracts.Queries
{
	public sealed class GetDecksQuery
	{
		public Guid UserId { get; set; }
	}
}
