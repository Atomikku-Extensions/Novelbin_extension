using Atomikku.Models.Extension;
using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IMainProvider
    {
        Task Execute(LightNovel lightNovel, TransactionType transactionType);
        Task ExecuteOld(Data data);
        Task<List<Book>> GetSearchBooks(string tittle);

        Task<Book> GetBookData(Book book);
    }
}