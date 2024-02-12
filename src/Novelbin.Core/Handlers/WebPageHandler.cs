using Atomikku.Models.Extension;
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

        public async Task<string> GetTitleOfPage(HtmlNode htmlNode)
        {
            var result = string.Empty;

            try
            {
                result = htmlNode.SelectSingleNode(Page.XPATH_TITLE)?.InnerText.Trim();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
            }

            return result;
        }

        public async Task<List<BookToSearch>> GetBooksAfterSearch(HtmlNode htmlNode)
        {
            List<BookToSearch> books = [];
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
                    var lightNovelUrl = titleNode.Attributes[Page.ELEMENT_HREF].Value;

                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(imageUrl)) break;

                    var bookFould = new BookToSearch
                    {
                        Tittle = title,
                        UrlImage = imageUrl,
                        Url = lightNovelUrl
                    };

                    books.Add(bookFould);
                }

                return books;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return books;
            }
        }

        public async Task<string> GetSecondTitleOfPage(HtmlNode htmlNode)
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

        public async Task<string> GetReleaseDateOfPage(HtmlNode htmlNode)
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

        public async Task<string> GetImageOfPage(HtmlNode htmlNode)
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

        public async Task<List<string>> GetGenresOfPage(HtmlNode htmlNode)
        {
            try
            {
                HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes(Page.XPATH_GENRE);
                return htmlNodeCollection.Select(node => node.InnerText.Trim()).ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return [];
            }
        }

        public async Task<string> GetStatusOfBook(HtmlNode htmlNode)
        {
            var result = string.Empty;
            try
            {
                result = htmlNode.SelectSingleNode(Page.XPATH_STATUS)?.InnerText.Trim();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
            }

            return result;
        }

        public async Task<string> GetSourceOfBook(HtmlNode htmlNode)
        {
            var result = string.Empty;
            try
            {
                result = htmlNode.SelectSingleNode(Page.XPATH_SOURCE)?.InnerText.Trim().Replace("Source:", "");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
            }

            return result;
        }

        public async Task<string> GetDescriptionOfPage(HtmlNode htmlNode)
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

        public async Task<string> GetAuthorOfPage(HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.SelectSingleNode(Page.XPATH_AUTHOR)?.InnerText;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
                return string.Empty;
            }
        }

        public async Task<List<Chapter>> GetChaptersOfPage(HtmlNode htmlNode)
        {
            List<Chapter> chapters = [];

            try
            {
                for (int div = 1; ; div++)
                {
                    HtmlNode node = htmlNode.SelectSingleNode(Page.GetDivOfChapter(div));

                    if (node is null) break;

                    var linesOne = node.SelectNodes(Page.XPATH_CHAPTER_LINKS);

                    foreach (var linkNode in linesOne)
                    {
                        var title = linkNode.Attributes[Page.ELEMENT_TITLE].Value;
                        var link = linkNode.Attributes[Page.ELEMENT_HREF].Value;

                        var chapter = new Chapter
                        {
                            ChapterNumber = title,
                            ChapterName = title,
                            ChapterOfBook = title,
                            Url = link,
                            ChapterReleaseDate = DateTime.Now.ToString("yyyy-MM-dd")
                        };

                        chapters.Add(chapter);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error. {exception.Message}");
            }

            return chapters;
        }

        public async Task<string> GetTextOfPage(HtmlNode htmlNode)
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