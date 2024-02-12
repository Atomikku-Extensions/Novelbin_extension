using Atomikku.Models.Extension;
using HtmlAgilityPack;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;
using Novelbin.Core.Extensions;

namespace Novelbin.Core.Providers
{
    public class MainProvider : IMainProvider
    {
        private readonly IPageExtractorService _pageExtractorService;
        private readonly IRequestService _requestService;
        private readonly IWebPageHandler _webPageHandler;
        private readonly IFileService _fileService;

        public MainProvider(
            IPageExtractorService pageExtractorService,
            IRequestService requestService,
            IWebPageHandler webPageHandler,
            IFileService fileService)
        {
            _pageExtractorService = pageExtractorService;
            _requestService = requestService;
            _webPageHandler = webPageHandler;
            _fileService = fileService;
        }

        public async Task<LightNovelToSearch> GetSearchBooks(string tittle)
        {
            string url = Page.URL.FormatingString(Page.SEARCH, tittle.Replace(" ", "+"));

            HtmlNode htmlNode = _requestService.GetHtmlNode(url);

            if (htmlNode is null) return await Task.FromResult(new LightNovelToSearch());

            var booksFould = await _webPageHandler.GetBooksAfterSearch(htmlNode);
            LightNovelToSearch outputs = new() { BooksFound = [], Tittle = tittle };
            foreach (var books in booksFould)
            {
                if (books is null) break;

                outputs.BooksFound.Add(new LightNovel
                {
                    Tittle = books.Tittle,
                    ImageUrl = books.UrlImage,
                    LightNovelUrl = books.Url
                });
            }

            return await Task.FromResult(outputs);
        }

        public async Task<LightNovel> GetBookData(LightNovel lightNovel)
        {
            HtmlNode htmlNode = _requestService.GetHtmlNode(lightNovel.LightNovelUrl);

            if (htmlNode is null) return lightNovel;

            lightNovel.Author ??= await _webPageHandler.GetAuthorOfPage(htmlNode);
            lightNovel.Genres ??= await _webPageHandler.GetGenresOfPage(htmlNode);
            lightNovel.Source ??= await _webPageHandler.GetSourceOfBook(htmlNode);
            lightNovel.Status ??= await _webPageHandler.GetStatusOfBook(htmlNode);
            lightNovel.Description ??= await _webPageHandler.GetDescriptionOfPage(htmlNode);

            return lightNovel;
        }

        public async Task<LightNovel?> GetChapter(LightNovel lightNovel)
        {
            HtmlNode htmlNodeWithChapters = _requestService.GetHtmlNode(lightNovel.LightNovelUrl, true);
            lightNovel.Chapters ??= await _webPageHandler.GetChaptersOfPage(htmlNodeWithChapters);
            return lightNovel;
        }

        public async Task<LightNovel> GetChapterOld(string tittle)
        {
            HtmlNode? htmlNode = _requestService.GetHtmlNode(tittle);
            if (htmlNode is null)
            {
                Console.WriteLine($"DocumentNode is null.");
                return new LightNovel { Tittle = tittle };
            }

            var title = await _webPageHandler.GetTitleOfPage(htmlNode);
            var imageUrl = await _webPageHandler.GetImageOfPage(htmlNode);
            var output = new LightNovel
            {
                Tittle = title,
                ImageUrl = imageUrl
            };

            return output;
        }

        public Task Execute(LightNovel lightNovel, TransactionType transactionType = TransactionType.SearchBooks)
        {
            throw new NotImplementedException();
        }
    }
}