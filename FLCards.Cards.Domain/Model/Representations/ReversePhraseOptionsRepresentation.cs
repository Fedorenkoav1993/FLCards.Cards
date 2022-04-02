using System.Collections.Generic;

namespace FLCards.Cards.Domain.Model.Representations
{
	public sealed class ReversePhraseOptionsRepresentation : Representation
	{
		public override RepresentationType Type => RepresentationType.ReversePhraseOptions;

		public ReversePhraseOptionsRepresentation(
			Phrase phrase,
			IList<Phrase> options)
		{
			Phrase = phrase;
			Options = options;
		}

		public Phrase Phrase { get; }

		public IList<Phrase> Options { get; }
	}
}
