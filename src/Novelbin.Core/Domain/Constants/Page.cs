namespace Novelbin.Core.Domain.Models
{
    public static class Page
    {
        // URL
        public const string URL = @"https://novelbin.net/";

        public const string SEARCH = @"search?keyword=";

        // XPATHs
        public const string XPATH_TEXT = "//*[@id=\"chr-content\"]";

        public const string XPATH_TITLE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_SECOND_TITLE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_IMAGE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_AUTHOR = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_RELEASE_DATE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_DESCRIPTION = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_CHAPTER = "//*[@id=\"chapter\"]/div/div/h2/a";
    }
}