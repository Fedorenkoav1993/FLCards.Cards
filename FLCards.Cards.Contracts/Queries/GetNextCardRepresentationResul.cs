using FLCards.Cards.Contracts.Data;

namespace FLCards.Cards.Contracts.Queries
{
	public sealed class GetNextCardRepresentationQueryResult
	{
		public RepresentationType RepresentationType { get; set; }

		public RepresentationDto Representation { get; set; }
	}
}
