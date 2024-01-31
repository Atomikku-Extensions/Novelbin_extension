using HtmlAgilityPack;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;
using Novelbin.Core.Extensions;
using System.Net;

namespace Novelbin.Core.Handlers
{
    public class WebPageHandler : IWebPageHandler
    {
        private const int MAX_BOOKS = 100;

        public string GetTitleOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_TITLE)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public Dictionary<string, string> GetBooksAfterSearch(HtmlNode htmlNode)
        {
            Dictionary<string, string> books = [];
            try
            {
                for (int bookItem = 2; bookItem < MAX_BOOKS; bookItem++)
                {
                    var node = htmlNode.SelectSingleNode(Page.XPATH_SEARCH.FormatingString($"[{bookItem}]"));
                    if (node is null) break;

                    var titleAndImageInfo = node.InnerHtml.Trim();

                    HtmlDocument htmlDoc = new();
                    htmlDoc.LoadHtml(titleAndImageInfo);

                    HtmlNode imgNode = htmlDoc.DocumentNode.SelectSingleNode(Page.XPATH_SELECT_IMAGE);
                    string? imageUrl = imgNode?.Attributes[Page.XPATH_ATTRIBUTE_SRC]?.Value;

                    HtmlNode titleNode = htmlDoc.DocumentNode.SelectSingleNode(Page.XPATH_SELECT_TITLE);
                    string? title = WebUtility.HtmlDecode(titleNode?.InnerText);

                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(imageUrl)) break;

                    books.Add(title, imageUrl);
                }

                return books;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return books;
            }
        }

        public string GetSecondTitleOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_SECOND_TITLE)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public string GetReleaseDateOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_RELEASE_DATE)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public string GetImageOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_SELECT_IMAGE)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public string GetDescriptionOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_DESCRIPTION)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public string GetAuthorOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_AUTHOR)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public string GetChaptersOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_CHAPTER)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public string GetTextOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_TEXT)?.InnerText.Trim() ?? string.Empty;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }
    }
}