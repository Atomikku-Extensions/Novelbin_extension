using Atomikku.Models.Extension;
using Novelbin.Core.Configuration;
using Novelbin.Core.Domain.Interfaces;
using SimpleInjector;

namespace Novelbin.Core
{
    public class Startup
    {
        private readonly IMainProvider _mainProvider;
        private readonly Container _container = new();

        public Startup()
        {
            DependencyInjectionConfiguration.RegisterDependencies(_container);

            _mainProvider = _container.GetInstance<IMainProvider>();
        }

        //public void Run(Data data) => _mainProvider.ExecuteOld(data);

        public void Run(LightNovel lightNovel) => _mainProvider.Execute(lightNovel);
    }
}