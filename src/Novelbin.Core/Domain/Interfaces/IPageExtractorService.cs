using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IPageExtractorService
    {
        Task StartExtractingPages(Data data);
    }
}