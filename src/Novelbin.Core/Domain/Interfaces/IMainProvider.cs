using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IMainProvider
    {
        Task Execute(Data data);
    }
}