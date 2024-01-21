namespace Novelbin.Core.Domain.Interfaces
{
    public interface ITranslatePageService
    {
        Task<string> Translate(string text);
    }
}