namespace FLCards.Cards.Domain.Model.Representations
{
	public sealed class ReversePhraseInputRepresentation : Representation
	{
		public override RepresentationType Type { get => RepresentationType.ReversePhraseInput; }

		public ReversePhraseInputRepresentation(Phrase phrase)
		{
			Phrase = phrase;
		}

		public Phrase Phrase { get; }
	}
}
