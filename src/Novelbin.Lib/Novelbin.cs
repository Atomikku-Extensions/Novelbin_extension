using Atomikku.Models.Extension;
using Novelbin.Core;

namespace Novelbin.Lib;

/// <summary>
/// Represents the Novelbin library.
/// </summary>
public class Novelbin
{
    private readonly Startup _startup;

    public Novelbin() => _startup = new Startup();

    /// <summary>
    /// Search books according the <see cref="LightNovelToSearch.Tittle"/>.
    /// </summary>
    /// <param name="lightNovel">Used to get the tittle.</param>
    /// <returns>The collection of books.</returns>
    public async Task<LightNovelToSearch> GetSearchBooks(LightNovelToSearch lightNovel) => await _startup.GetSearchBooks(lightNovel);

    /// <summary>
    /// Get the book data.
    /// </summary>
    /// <param name="lightNovel">Used to update the information.</param>
    /// <returns>The <see cref="LightNovel"/> with data.</returns>
    public async Task<LightNovel> GetBookData(LightNovel lightNovel) => await _startup.GetBookData(lightNovel);

    /// <summary>
    /// Get all chapters from the book.
    /// </summary>
    /// <param name="lightNovel">Used to update the information.</param>
    /// <returns>The <see cref="LightNovel"/> with the chapters.</returns>
    public async Task<LightNovel> GetChapters(LightNovel lightNovel) => await _startup.GetChapters(lightNovel);
}