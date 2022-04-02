using FLCards.Cards.ApplicationServices.Services;
using FLCards.Cards.Contracts.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FLCards.Cards.Controllers
{
	[ApiController]
	public class LearnController : ControllerBase
	{
		public LearnController(ILearningService learningService) 
		{
			LearningService = learningService;
		}

		private ILearningService LearningService { get; }

		[HttpPost]
		[Route("learn/get-next-card")]
		public async Task<ObjectResult> GetNextCardRepresentation(GetNextCardRepresentationQuery getNextCardRepresentationQuery)
		{
			var result = await LearningService.GetNextRepresentation(getNextCardRepresentationQuery);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}
	}
}
