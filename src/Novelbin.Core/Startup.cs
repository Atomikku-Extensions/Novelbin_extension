using Novelbin.Core.Configuration;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;
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

        public void Run(Data data)
        {
            _mainProvider.Execute(data);
        }
    }
}