using FLCards.Cards.Contracts.Queries;
using FLCards.Common.Infrastructure;
using System.Threading.Tasks;

namespace FLCards.Cards.ApplicationServices.Services
{
	public interface ILearningService
	{
		Task<Result<GetNextCardRepresentationQueryResult, string>> GetNextRepresentation(
			GetNextCardRepresentationQuery getNextCardRepresentationQuery);
	}
}
