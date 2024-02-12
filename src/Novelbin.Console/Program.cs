using Atomikku.Models.Extension;
using Novelbin.Core.Handlers;
using Novelbin.Core.Providers;
using Novelbin.Core.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        RequestService requestService = new RequestService();
        DirectoryProvider directoryProvider = new DirectoryProvider();

        PageExtractorService pageExtractorService = new PageExtractorService(requestService);
        FileService fileService = new FileService(directoryProvider);
        WebPageHandler webPageHandler = new WebPageHandler();

        var main = new MainProvider(
            pageExtractorService,
            requestService,
            webPageHandler,
            fileService
            );

        // Search for light novels.
        //var tittleSearch = lightNovel_WhenSearchFirtTime();
        //var lightNovelsFound = main.GetSearchBooks(tittleSearch.Tittle).Result;

        // Get all data from light novel.
        //var lightNovel = lightNovel_WhenAfterGetallData_GetAllChapters();
        //var lightNovelData = main.GetBookData(lightNovel).Result;

        // Get Chapter from light novel.
        var lightNovelFull = lightNovel_WhenAfterGetallData_GetAllChapters();
        var lightNovelWithChapter = main.GetChapter(lightNovelFull).Result;
    }

    private static LightNovelToSearch lightNovel_WhenSearchFirtTime() => new()
    {
        Tittle = "The cursed prince"
    };

    private static LightNovel lightNovel_WhenAfterSearch_FindAllData() => new()
    {
        Tittle = "The cursed prince",
        LightNovelUrl = "https://novelbin.com/b/the-cursed-prince",
        ImageUrl = "https://novelbin.net/media/novel/the-cursed-prince.jpg"
    };

    private static LightNovel lightNovel_WhenAfterGetallData_GetAllChapters() => new()
    {
        Tittle = "The cursed prince",
        LightNovelUrl = "https://novelbin.com/b/the-cursed-prince",
        ImageUrl = "https://novelbin.net/media/novel/the-cursed-prince.jpg",
        Source = "Webnovel",
        Author = "Missrealitybites",
        Genres = ["Fantasy", "Romance"],
        Status = "Ongoing",
        Description = "The cursed prince is a story about a prince who was cursed by a witch. He was cursed to be a wolf every night. The only way to break the curse is to find true love. Will he be able to find true love and break the curse?"
    };
}