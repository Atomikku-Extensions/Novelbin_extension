using HtmlAgilityPack;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;
using System.Text.RegularExpressions;
using System.Web;

namespace Novelbin.Core.Services
{
    /// <summary>Represents the Request services (GET, POST...).</summary>
    public class RequestService : NovelBinServiceBase, IRequestService
    {
        private readonly HtmlWeb _htmlWeb;

        public RequestService()
        {
            _htmlWeb = new HtmlWeb();
        }

        public string GetSearchPage(string tittle)
        {
            string url = Path.Combine(Page.URL, Page.SEARCH, tittle.Replace(" ", "%20"));
            var doc = _htmlWeb.Load(url);
            var text = doc.DocumentNode.SelectSingleNode("//*[@id=\"list-page\"]/div[1]/div")?.InnerText.Trim();
            if (string.IsNullOrEmpty(text)) return "";

            var decodedText = HttpUtility.HtmlDecode(text);
            return decodedText;
        }

        public HtmlNode? GetHtmlNode(string url)
        {
            try
            {
                HtmlDocument doc = _htmlWeb.Load(url);
                HtmlNode documentNode = doc.DocumentNode;
                return documentNode;
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"Error - {url}.");
                Console.WriteLine(exeption.Message);
                return null;
            }
        }

        /// <summary>Request page.</summary>
        /// <param name="url">Used to get the HTML body.</param>
        /// <returns>String of page.</returns>
        public string GetPageStringWithXPath(string url, string xPath, List<string>? tags = null)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(xPath)) return string.Empty;

            string decodedText = string.Empty;

            try
            {
                var doc = _htmlWeb.Load(url);
                var text = doc.DocumentNode.SelectSingleNode(xPath)?.InnerText.Trim();
                if (string.IsNullOrEmpty(text)) return decodedText;

                decodedText = HttpUtility.HtmlDecode(text);
                decodedText = RemoveTag(decodedText, tags);
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"Error - {url}.");
                Console.WriteLine(exeption.Message);
            }

            return decodedText;
        }

        #region Private Methods

        // TODO: Refactor this method - Return is not necessary.
        private static string RemoveTag(string decodedText, List<string>? tags)
        {
            if (tags == null || !tags.Any()) return decodedText;
            foreach (var tag in tags)
            {
                string pattern = $"\\s*{tag}";
                decodedText = Regex.Replace(decodedText, pattern, string.Empty);
            }

            return decodedText;
        }

        #endregion Private Methods
    }
}