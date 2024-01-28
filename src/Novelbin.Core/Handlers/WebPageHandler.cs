using HtmlAgilityPack;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Handlers
{
    public class WebPagehandler : IWebPageHandler
    {
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
                return htmlNode.SelectSingleNode(Page.XPATH_IMAGE)?.InnerText.Trim() ?? string.Empty;
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