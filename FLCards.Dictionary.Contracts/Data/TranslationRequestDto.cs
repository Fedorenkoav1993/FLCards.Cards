namespace FLCards.Dictionary.Contracts.Data
{
	public sealed class TranslationRequestDto
	{
		public string OriginalValue { get; set; }

		public string OriginalValueLanguage { get; set; }

		public string TranslateToLanguage { get; set; }
	}
}
