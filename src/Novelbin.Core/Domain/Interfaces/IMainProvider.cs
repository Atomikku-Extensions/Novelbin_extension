using Atomikku.Models.Extension;
using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IMainProvider
    {
        Task Execute(Data data);

        Task<Output> GetTitleWithImage(Input input);

        Task<Output> GetChapter(Input input);

        Task<Output> GetChapterOld(Input input);

        Task<List<Output>> GetSearchBooks(string tittle);
    }
}