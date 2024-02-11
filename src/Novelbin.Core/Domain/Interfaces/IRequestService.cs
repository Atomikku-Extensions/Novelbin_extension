using HtmlAgilityPack;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IRequestService
    {
        HtmlNode GetHtmlNode(string url);

        string GetPageStringWithXPath(string url, string xPath, List<string>? tags = null);

        string GetSearchPage(string tittle);
    }
}