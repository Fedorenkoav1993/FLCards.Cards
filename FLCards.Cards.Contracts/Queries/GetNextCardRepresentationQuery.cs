using FLCards.Cards.Contracts.Data;

namespace FLCards.Cards.Contracts.Queries
{
	public sealed class GetNextCardRepresentationQuery
	{
		public string DeckId { get; set; }

		public RepresentationType RepresentationType { get; set; }
	}
}
