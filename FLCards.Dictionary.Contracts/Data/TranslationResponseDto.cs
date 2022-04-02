namespace FLCards.Dictionary.Contracts.Data
{
	public sealed class TranslationResponseDto
	{
		public string OriginalValue { get; set; }

		public string OriginalValueLanguage { get; set; }

		public string TranslatedValue { get; set; }

		public string TranslatedValueLanguage { get; set; }
	}
}
