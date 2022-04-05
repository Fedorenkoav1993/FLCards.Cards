using System.Linq;

namespace FLCards.Dictionary.DataAccess.Repositories
{
    internal sealed class DictionaryRepository : IDictionaryRepository
    {
        public string[] FindTranslations(string value, string languageFrom, string languageTo)
        {
			using (var context = new PrimaryDbContext())
			{
                var translations = context.Dictionary.AsQueryable();

                switch (languageFrom)
                {
                    case "en":
                        translations = translations.Where(d => d.English.StartsWith(value));
                        break;

                    case "ru":
                        translations = translations.Where(d => d.Russian.StartsWith(value));
                        break;
                }

                translations = translations.Take(5);

                switch (languageTo)
                {
                    case "en":
                        return translations.Select(d => d.English).ToArray();

                    case "ru":
                        return translations.Select(d => d.Russian).ToArray();
                }
            }

            return new string[0];
		}
    }
}
