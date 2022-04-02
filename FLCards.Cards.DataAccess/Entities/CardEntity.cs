using System;

namespace FLCards.Cards.DataAccess.Entities
{
	internal sealed class CardEntity
	{
		public Guid Id { get; set; }

		public string OriginalValue { get; set; }
		
		public string OriginalLanguage { get; set; }

		public string TranslationValue { get; set; }
		
		public string TranslationLanguage { get; set; }

		public string ImageUri { get; set; }

		public Guid DeckId { get; set; }

		public int PhraseOptionsCount{ get; set; }

		public int ReversePhraseOptionsCount { get; set; }

		public int PhraseInputCount { get; set; }

		public int ReversePhraseInputCount { get; set; }
	}
}
