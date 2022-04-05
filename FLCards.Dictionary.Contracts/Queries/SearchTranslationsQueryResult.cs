using FLCards.Cards.Contracts.Data;

namespace FLCards.Dictionary.Contracts.Queries
{
	public sealed class SearchTranslationsQueryResult
	{
		public PhraseDto[] Translations { get; set; }
	}
}
