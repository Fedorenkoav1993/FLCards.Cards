using Microsoft.AspNetCore.Mvc;

namespace FLCards.Dictionary.Controllers
{
	[ApiController]
	[Route("dictionary")]
	public class DictionaryController : ControllerBase
	{
		public DictionaryController()
		{
		}

		[HttpGet]
		[Route("translate")]
		public ObjectResult Translate()
		{
			return new ObjectResult(null);
		}
	}
}
