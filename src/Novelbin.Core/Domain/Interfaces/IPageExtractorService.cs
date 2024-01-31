using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IPageExtractorService
    {
        ChapterOld GetPageText(WebConfiguration web, uint chapter);

        Task StartExtractingPages(Data data);
    }
}