using FLCards.Cards.Contracts.Data;
using FLCards.Common.Contracts;
using FLCards.Common.Infrastructure;
using FLCards.Dictionary.ApplicationServices.Clients;
using FLCards.Dictionary.Contracts.Queries;
using FLCards.Dictionary.DataAccess.Repositories;
using System.Linq;

namespace FLCards.Dictionary.ApplicationServices.Services
{
    public class DictionaryService : IDictionaryService
    {
        public DictionaryService(
            IDictionaryRepository dictionaryRepository,
            ICambridgeDictionaryClient cambridgeDictionaryClient)
        {
            DictionaryRepository = dictionaryRepository;
            CambridgeDictionaryClient = cambridgeDictionaryClient;
        }

        private IDictionaryRepository DictionaryRepository { get; }
        
        private ICambridgeDictionaryClient CambridgeDictionaryClient { get; }

        public Result<SearchTranslationsQueryResult, FailedResult> SearchTranslations(SearchTranslationsQuery searchTranslationsQuery)
        {
            var translations = DictionaryRepository.FindTranslations(
                searchTranslationsQuery.Phrase.Value,
                searchTranslationsQuery.Phrase.Language,
                searchTranslationsQuery.LanguageTranslateTo);

            if (!translations.Any(t => t == searchTranslationsQuery.Phrase.Value))
            {
                var cambridgeTranslation =
                    CambridgeDictionaryClient.FindTranslations(
                        searchTranslationsQuery.Phrase.Value,
                        searchTranslationsQuery.Phrase.Language,
                        searchTranslationsQuery.LanguageTranslateTo);

                if (cambridgeTranslation.IsSuccess())
                {
                    translations = translations.Append(cambridgeTranslation.SuccessResult).ToArray();
                }
                else
                {
                    // TODO Logging
                }
            }

            if (translations == null)
            {
                return new FailedResult
                {
                    // TODO Replace error message
                    ErrorMessage = "Unknown Error"
                };
            }

            return new SearchTranslationsQueryResult
            {
                Translations = translations
                .Select(t => new PhraseDto { Value = t, Language = searchTranslationsQuery.LanguageTranslateTo })
                .ToArray()
            };
        }
    }
}
