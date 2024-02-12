using Atomikku.Models.Extension;
using Novelbin.Core.Configuration;
using Novelbin.Core.Domain.Interfaces;
using SimpleInjector;

namespace Novelbin.Core
{
    public class Startup
    {
        private readonly Container _container = new();
        private readonly IMainProvider _mainProvider;

        public Startup()
        {
            DependencyInjectionConfiguration.RegisterDependencies(_container);
            _mainProvider = _container.GetInstance<IMainProvider>();
        }

        public async Task<LightNovelToSearch> GetSearchBooks(LightNovelToSearch lightNovel) => await _mainProvider.GetSearchBooks(lightNovel);

        public async Task<LightNovel> GetBookData(LightNovel lightNovel) => await _mainProvider.GetBookData(lightNovel);

        public async Task<LightNovel> GetChapters(LightNovel lightNovel) => await _mainProvider.GetChapter(lightNovel);
    }
}