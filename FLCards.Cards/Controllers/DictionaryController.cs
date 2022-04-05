using FLCards.Dictionary.ApplicationServices.Services;
using FLCards.Dictionary.Contracts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FLCards.Cards.Controllers
{
    [ApiController]
    public class DictionaryController : ControllerBase
    {
		public DictionaryController(IDictionaryService dictionaryService)
		{
			DictionaryService = dictionaryService;
		}

		private IDictionaryService DictionaryService { get; }

        [HttpPost]
		[Route("dictionary/search")]
		public ObjectResult Search(SearchTranslationsQuery searchTranslationsQuery)
		{
			var result = DictionaryService.SearchTranslations(searchTranslationsQuery);

			return result.IsSuccess()
				? Ok(result.SuccessResult)
				: (ObjectResult)UnprocessableEntity(result.FailedResult);
		}
	}
}
