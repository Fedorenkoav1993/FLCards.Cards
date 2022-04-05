using FLCards.Common.Contracts;
using FLCards.Common.Infrastructure;

namespace FLCards.Dictionary.ApplicationServices.Clients
{
    public interface ICambridgeDictionaryClient
    {
        Result<string, FailedResult> FindTranslations(string value, string languageFrom, string languageTo);

    }
}
