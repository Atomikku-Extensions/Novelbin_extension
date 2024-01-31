using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Handlers;
using Novelbin.Core.Providers;
using Novelbin.Core.Services;
using SimpleInjector;

namespace Novelbin.Core.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterDependencies(Container container)
        {
            // Services
            container.Register<IFileService, FileService>();
            container.Register<IRequestService, RequestService>();
            container.Register<ITranslatePageService, TranslatePageService>();
            container.Register<IPageExtractorService, PageExtractorService>();

            // Providers
            container.Register<IMainProvider, MainProvider>();
            container.Register<IDirectoryProvider, DirectoryProvider>();

            // Handlers
            container.Register<IWebPageHandler, WebPageHandler>();

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            container.Verify();
        }
    }
}