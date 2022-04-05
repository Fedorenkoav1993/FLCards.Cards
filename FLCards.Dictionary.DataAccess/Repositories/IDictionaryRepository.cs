namespace FLCards.Dictionary.DataAccess.Repositories
{
    public  interface IDictionaryRepository
    {
        string[] FindTranslations(string value, string languageFrom, string languageTo);
    }
}
