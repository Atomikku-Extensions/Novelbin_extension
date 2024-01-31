namespace Novelbin.Core.Domain.Models
{
    public static class Page
    {
        // URL
        public const string URL = @"https://novelbin.net/";

        public const string SEARCH = @"search?keyword=";
        public const string NOVEL_BOOK = @"novel-book";

        // XPATHs
        public const string XPATH_TEXT = "//*[@id=\"chr-content\"]";

        public const string XPATH_TITLE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_SECOND_TITLE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_SEARCH = "//*[@id=\"list-page\"]/div[1]/div/div"; // Concatenate

        public const string XPATH_SELECT_TITLE = "//h3[@class='novel-title']/a";
        public const string XPATH_SELECT_IMAGE = "//img[@class='cover']";
        public const string XPATH_ATTRIBUTE_SRC = "src";

        public const string XPATH_AUTHOR = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_RELEASE_DATE = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_DESCRIPTION = "//*[@id=\"chapter\"]/div/div/h2/a";
        public const string XPATH_CHAPTER = "//*[@id=\"chapter\"]/div/div/h2/a";
    }
}