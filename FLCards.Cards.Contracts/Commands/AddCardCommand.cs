using System;
using FLCards.Cards.Contracts.Data;

namespace FLCards.Cards.Contracts.Commands
{
	public sealed class AddCardCommand
	{
		public Guid DeckId { get; set; }

		public PhraseDto Phrase { get; set; }

		public PhraseDto Translation { get; set; }

		public string ImageUrl { get; set; }
	}
}
