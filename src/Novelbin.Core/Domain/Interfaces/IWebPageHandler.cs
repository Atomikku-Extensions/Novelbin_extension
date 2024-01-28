using HtmlAgilityPack;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IWebPageHandler
    {
        string GetAuthorOfPage(HtmlNode htmlNode);
        string GetChaptersOfPage(HtmlNode htmlNode);
        string GetDescriptionOfPage(HtmlNode htmlNode);
        string GetImageOfPage(HtmlNode htmlNode);
        string GetReleaseDateOfPage(HtmlNode htmlNode);
        string GetSecondTitleOfPage(HtmlNode htmlNode);
        string GetTextOfPage(HtmlNode htmlNode);
        string GetTitleOfPage(HtmlNode htmlNode);
    }
}