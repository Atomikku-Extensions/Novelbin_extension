using Novelbin.Core.Domain.Interfaces;

namespace Novelbin.Core.Providers
{
    public class DirectoryProvider : IDirectoryProvider
    {
        public bool HasDirectory(string path) => Directory.Exists(path);

        public void CreateDirectory(string path) => Directory.CreateDirectory(path);
    }
}