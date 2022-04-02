namespace FLCards.Cards.Contracts.Data
{
	public sealed class PhraseOptionsRepresentationDto : RepresentationDto
	{
		public PhraseDto Phrase { get; set; }

		public PhraseDto[] Options { get; set; }
	}
}
