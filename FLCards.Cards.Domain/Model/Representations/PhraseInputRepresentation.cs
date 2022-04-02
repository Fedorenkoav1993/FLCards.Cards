namespace FLCards.Cards.Domain.Model.Representations
{
	public sealed class PhraseInputRepresentation : Representation
	{
		public override RepresentationType Type { get => RepresentationType.PhraseInput; }

		public PhraseInputRepresentation(Phrase phrase)
		{
			Phrase = phrase;
		}

		public Phrase Phrase { get; }
	}
}
