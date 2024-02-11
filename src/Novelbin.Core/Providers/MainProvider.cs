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

        public async Task<List<Book>> GetSearchBooks(string tittle)
        {
            string url = Page.URL.FormatingString(Page.SEARCH, tittle.Replace(" ", "+"));

            HtmlNode htmlNode = _requestService.GetHtmlNode(url);

            if (htmlNode is null) return [];

            Dictionary<string, string> books = await _webPageHandler.GetBooksAfterSearch(htmlNode);
            List<Book> outputs = [];
            foreach (var (title, imageUrl) in books)
            {
                if (books is null || !books.Any()) break;

                outputs.Add(new Book
                {
                    Tittle = title,
                    ImageUrl = imageUrl
                });
            }

            return await Task.FromResult(outputs);
        }

        public async Task<Book> GetBookData(Book book)
        {
            var url = Page.URL.FormatingString(Page.N, book.Tittle.ToLower().Replace(' ', '-'), Page.CHAPTERS_TITLE);
            HtmlNode htmlNode = _requestService.GetHtmlNode(url);

            if (htmlNode is null) return null;

            // TODO: Refactor this in the future.
            //Task<string> secondTitleTask = _webPageHandler.GetSecondTitleOfPage(htmlNode);

            Task<string> statusTask = _webPageHandler.GetStatusOfBook(htmlNode);
            Task<string> descriptionTask = _webPageHandler.GetDescriptionOfPage(htmlNode);
            Task<string> authorTask = _webPageHandler.GetAuthorOfPage(htmlNode);
            Task<string> releaseData = _webPageHandler.GetReleaseDateOfPage(htmlNode);
            Task<List<Chapter>> chapters = _webPageHandler.GetChaptersOfPage(htmlNode);

            await Task.WhenAll(statusTask, descriptionTask, authorTask, releaseData, chapters);

            book.Status = await statusTask;
            book.Description = await descriptionTask;
            book.Author = await authorTask;
            book.ReleaseDate = await releaseData;
            book.Chapters = await chapters;

            return book;
        }

        public async Task<Book?> GetChapter(Book input)
        {
            HtmlNode? htmlNode = _requestService.GetHtmlNode(input.Tittle);

            if (htmlNode is null) return null;

            var title = await _webPageHandler.GetTitleOfPage(htmlNode);
            var secondTitle = await _webPageHandler.GetSecondTitleOfPage(htmlNode);
            var releaseDate = await _webPageHandler.GetReleaseDateOfPage(htmlNode);
            var imageUrl = await _webPageHandler.GetImageOfPage(htmlNode);
            var description = await _webPageHandler.GetDescriptionOfPage(htmlNode);
            var author = await _webPageHandler.GetAuthorOfPage(htmlNode);

            var chapter = new List<Chapter>
            {
                new()
                {
                    Url = "",
                    ChapterNumber = "",
                    ChapterOfBook = ""
                }
            };

            return new Book
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

        public async Task<Book> GetChapterOld(string tittle)
        {
            HtmlNode? htmlNode = _requestService.GetHtmlNode(tittle);
            if (htmlNode is null)
            {
                Console.WriteLine($"DocumentNode is null.");
                return new Book { Tittle = tittle };
            }

            var title = await _webPageHandler.GetTitleOfPage(htmlNode);
            var imageUrl = await _webPageHandler.GetImageOfPage(htmlNode);
            var output = new Book
            {
                Tittle = title,
                ImageUrl = imageUrl
            };

            return output;
        }

        /// <summary>Execute the process to export chapter.</summary>
        public async Task ExecuteOld(Data data) => await Task.WhenAll(
            //_fileService.CheckFolders(data),
            _pageExtractorService.StartExtractingPages(data),
            _fileService.StartCreatingFiles(data));

        public Task Execute(LightNovel lightNovel)
        {
            return lightNovel.TransactionType switch
            {
                TransactionType.SearchBooks => GetSearchBooks(lightNovel.Books.FirstOrDefault().Tittle),
                TransactionType.SearchBook => GetBookData(lightNovel.Books.FirstOrDefault()),
                TransactionType.SearchChapters => GetChapter(lightNovel.Books.FirstOrDefault()),
                _ => Task.CompletedTask,
            };
        }
    }
}