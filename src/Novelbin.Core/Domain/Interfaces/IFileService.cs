using Novelbin.Core.Domain.Models;

namespace Novelbin.Core.Domain.Interfaces
{
    public interface IFileService
    {
        Task CheckFolders(Data data);

        Task StartCreatingFiles(Data data);

        void CreateDirectory(string path, string folderName);

        string CheckFolderExist(string path, string folderName);
    }
}