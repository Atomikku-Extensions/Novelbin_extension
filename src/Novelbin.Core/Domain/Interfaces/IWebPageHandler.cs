using Atomikku.Models.Extension;
using HtmlAgilityPack;

namespace Novelbin.Core.Domain.Interfaces;

/// <summary>
/// Represents the WebPageHandler services.
/// </summary>
public interface IWebPageHandler
{
    Task<Dictionary<string, string>> GetBooksAfterSearch(HtmlNode htmlNode);

    Task<string> GetAuthorOfPage(HtmlNode htmlNode);

    Task<string> GetDescriptionOfPage(HtmlNode htmlNode);

    Task<string> GetImageOfPage(HtmlNode htmlNode);

    Task<string> GetReleaseDateOfPage(HtmlNode htmlNode);

    Task<string> GetSecondTitleOfPage(HtmlNode htmlNode);

    Task<string> GetTextOfPage(HtmlNode htmlNode);

    Task<string> GetTitleOfPage(HtmlNode htmlNode);

    Task<List<Chapter>> GetChaptersOfPage(HtmlNode htmlNode);

    Task<string> GetStatusOfBook(HtmlNode htmlNode);
}