namespace FLCards.Cards.Domain.Model
{
	public sealed class Phrase
	{
		public Phrase(string value, string language)
		{
			Value = value;
			Language = language;
		}

		public string Value { get; }

		public string Language { get; }
	}
}
