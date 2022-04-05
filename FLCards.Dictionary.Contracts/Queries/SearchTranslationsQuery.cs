using FLCards.Cards.Contracts.Data;

namespace FLCards.Dictionary.Contracts.Queries
{
	public sealed class SearchTranslationsQuery
	{
		public PhraseDto Phrase { get; set; }

		public string LanguageTranslateTo { get; set; }
	}
}
