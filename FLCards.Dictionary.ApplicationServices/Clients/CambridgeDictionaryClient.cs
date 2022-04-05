using FLCards.Common.Contracts;
using FLCards.Common.Infrastructure;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace FLCards.Dictionary.ApplicationServices.Clients
{
    internal class CambridgeDictionaryClient : ICambridgeDictionaryClient
    {
        public Result<string, FailedResult> FindTranslations(string value, string languageFrom, string languageTo)
        {
            var httpClient = new HttpClient();

            var result = httpClient.GetAsync("https://dictionary.cambridge.org/ru/словарь/англо-русский/" + value).Result;

            var resultAsStr = result.Content.ReadAsStringAsync().Result;

            var rx = new Regex("<span class=\"trans dtrans dtrans-se \" lang=\"ru\">(.*?)</span>");

            var translation = rx.Match(resultAsStr).Groups[1].Value;

            return !string.IsNullOrWhiteSpace(translation) 
                ? translation
                : new FailedResult { ErrorMessage = $"Cannot find translation for {value}." };
        }
    }
}
