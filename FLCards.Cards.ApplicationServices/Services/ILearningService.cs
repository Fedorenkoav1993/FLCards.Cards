using FLCards.Cards.Contracts.Queries;
using FLCards.Cards.Infrastructure;
using System.Threading.Tasks;

namespace FLCards.Cards.ApplicationServices.Services
{
	public interface ILearningService
	{
		Task<Result<GetNextCardRepresentationQueryResult, string>> GetNextRepresentation(
			GetNextCardRepresentationQuery getNextCardRepresentationQuery);
	}
}
