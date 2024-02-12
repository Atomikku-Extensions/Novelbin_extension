using Atomikku.Models.Extension;

namespace Novelbin.Core.Domain.Interfaces;

public interface IMainProvider
{
    Task<LightNovelToSearch> GetSearchBooks(LightNovelToSearch lightNovelToSearch);

    Task<LightNovel> GetBookData(LightNovel lightNovel, bool forceUpdate = false);

    Task<LightNovel> GetChapter(LightNovel lightNovel, bool forceUpdate = false);
}