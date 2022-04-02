using System;

namespace FLCards.Cards.Contracts.Commands
{
	public sealed class RemoveDeckCommand
	{
		public Guid DeckId { get; set; }
	}
}
