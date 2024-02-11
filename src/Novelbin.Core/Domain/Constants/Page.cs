namespace Novelbin.Core.Domain.Models
{
    public static class Page
    {
        // URL
        public const string URL = @"https://novelbin.net/";

        public const string N = @"n/";
        public const string CHAPTERS_TITLE = @"#tab-chapters-title";

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
        public const string XPATH_STATUS = "//*[@id=\"novel\"]/div[1]/div[1]/div[3]/ul/li[1]/a";

        public const string XPATH_LIST_CHAPTER = "//*[@id=\"list-chapter\"]/div/div/div/div[1]/div[1]/ul/li[1]/a";
        public const string XPATH_CHAPTER_LINKS = "//div[@class='col-xs-12 col-sm-4 col-md-4']//ul[@class='list-chapter']//li/a";

        // Elements
        public const string ELEMENT_TITLE = "title";

        public const string ELEMENT_HREF = "href";

        public static string GetDivOfChapter(int div) =>
            $"//*[@id=\"list-chapter\"]/div/div/div/div/div[{div}]";
    }
}