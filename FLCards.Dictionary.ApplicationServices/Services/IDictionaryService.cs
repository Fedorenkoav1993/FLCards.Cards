using FLCards.Common.Contracts;
using FLCards.Common.Infrastructure;
using FLCards.Dictionary.Contracts.Queries;

namespace FLCards.Dictionary.ApplicationServices.Services
{
	public interface  IDictionaryService
	{
		Result<SearchTranslationsQueryResult, FailedResult> SearchTranslations(SearchTranslationsQuery searchTranslationsQuery);
	}
}
