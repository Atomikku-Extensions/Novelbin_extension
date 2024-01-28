using Atomikku.Models.Extension;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Services
{
    public class PageExtractorService : NovelBinServiceBase, IPageExtractorService
    {
        private readonly IRequestService _requestService;

        public PageExtractorService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public Task<Output> GetTittle(Input input)
        {
            var tittle = input.Tittle;
            return null;
        }

        public Task StartExtractingPages(Data data)
        {
            data.Chapters = GetChapters(data);
            return Task.CompletedTask;
        }

        #region Private Methods

        private Output SearchPage(string tittle)
        {
            var page = _requestService.GetSearchPage(tittle);
            return new Output();
        }

        private List<ChapterOld> GetChapters(Data data)
        {
            List<ChapterOld> chapterCollection = [];
            for (uint chapter = data.FileConfiguration.StartChapter; chapter <= data.FileConfiguration.EndChapter; chapter++)
            {
                var chapterWithContext = GetPageText(data.WebConfiguration, chapter);
                if (chapterWithContext != null) chapterCollection.Add(chapterWithContext);
            }
            return chapterCollection;
        }

        // TODO: Refactor this method - Is not neccessary call 'GetPageString' 2 times.
        public ChapterOld GetPageText(WebConfiguration web, uint chapter)
        {
            var url = $"{web.Url}{chapter}/";
            var chapterTitle = _requestService.GetPageStringWithXPath(url, web.XPathTitle);
            var chapterText = _requestService.GetPageStringWithXPath(url, web.XPathText, web.TagsToFix);
            if (string.IsNullOrEmpty(chapterText))
            {
                Console.WriteLine($"Error when proccess the Chapter: {chapter}.");
                return null;
            }
            Console.WriteLine($"Success to process the Chapter: {chapter}.");
            return new ChapterOld(chapter, $"The Cursed Prince - {chapterTitle}", chapterText);
        }

        #endregion Private Methods
    }
}