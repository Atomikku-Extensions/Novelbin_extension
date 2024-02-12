using Atomikku.Models.Extension;
using HtmlAgilityPack;
using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces;

/// <summary>
/// Represents the WebPageHandler services.
/// </summary>
public interface IWebPageHandler
{
    Task<List<BookToSearch>> GetBooksAfterSearch(HtmlNode htmlNode);

    Task<string> GetAuthorOfPage(HtmlNode htmlNode);

    Task<string> GetDescriptionOfPage(HtmlNode htmlNode);

    Task<string> GetImageOfPage(HtmlNode htmlNode);

    Task<string> GetReleaseDateOfPage(HtmlNode htmlNode);

    Task<string> GetSecondTitleOfPage(HtmlNode htmlNode);

    Task<string> GetTextOfPage(HtmlNode htmlNode);

    Task<string> GetTitleOfPage(HtmlNode htmlNode);

    Task<List<Chapter>> GetChaptersOfPage(HtmlNode htmlNode);

    Task<string> GetStatusOfBook(HtmlNode htmlNode);

    Task<List<string>> GetGenresOfPage(HtmlNode htmlNode);

    Task<string> GetSourceOfBook(HtmlNode htmlNode);
}