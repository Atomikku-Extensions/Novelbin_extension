using Atomikku.Models.Extension;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IMainProvider
    {
        Task Execute(LightNovel lightNovel, TransactionType transactionType = TransactionType.SearchBooks);

        Task<LightNovelToSearch> GetSearchBooks(string tittle);

        Task<LightNovel> GetBookData(LightNovel book);
    }
}