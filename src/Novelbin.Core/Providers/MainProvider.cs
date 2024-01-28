using Atomikku.Models.Extension;
using HtmlAgilityPack;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;

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

        public async Task<Output> GetTitleWithImage(Input input)
        {
            HtmlNode? htmlNode = _requestService.GetHtmlNode(input.Tittle);

            if (htmlNode is null) return new Output();

            var title = _webPageHandler.GetTitleOfPage(htmlNode);
            var imageUrl = _webPageHandler.GetImageOfPage(htmlNode);

            return new Output
            {
                Tittle = title,
                ImageUrl = imageUrl
            };
        }

        public async Task<Output> GetChapter(Input input)
        {
            HtmlNode? htmlNode = _requestService.GetHtmlNode(input.Tittle);

            if (htmlNode is null) return new Output();

            var title = _webPageHandler.GetTitleOfPage(htmlNode);
            var secondTitle = _webPageHandler.GetSecondTitleOfPage(htmlNode);
            var releaseDate = _webPageHandler.GetReleaseDateOfPage(htmlNode);
            var imageUrl = _webPageHandler.GetImageOfPage(htmlNode);
            var description = _webPageHandler.GetDescriptionOfPage(htmlNode);
            var author = _webPageHandler.GetAuthorOfPage(htmlNode);

            var chapter = new List<Chapter>
            {
                new()
                {
                    Url = "",
                    ChapterNumber = ""
                }
            };

            return new Output
            {
                Tittle = title,
                SecondTittle = secondTitle,
                ReleaseDate = releaseDate,
                ImageUrl = imageUrl,
                Description = description,
                Author = author,
                Chapters = chapter
            };
        }

        public async Task<Output> GetChapterOld(Input input)
        {
            HtmlNode? htmlNode = _requestService.GetHtmlNode(input.Tittle);
            if (htmlNode is null)
            {
                Console.WriteLine($"DocumentNode is null.");
                return new Output();
            }

            var title = _webPageHandler.GetTitleOfPage(htmlNode);
            var imageUrl = _webPageHandler.GetImageOfPage(htmlNode);
            var output = new Output
            {
                Tittle = title,
                ImageUrl = imageUrl
            };

            return output;
        }

        /// <summary>Execute the process to export chapter.</summary>
        public async Task Execute(Data data) => await Task.WhenAll(
            //_fileService.CheckFolders(data),
            _pageExtractorService.StartExtractingPages(data),
            _fileService.StartCreatingFiles(data));
    }
}