using System;

namespace FLCards.Cards.Contracts.Data
{
	public sealed class CardDto
	{
		public Guid Id { get; set; }

		public PhraseDto Original { get; set; }

		public PhraseDto Translation { get; set; }

		public string ImageUri { get; set; }
	}
}
