using Moq;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;
using Novelbin.Core.Services;

namespace Novelbin.Core.Tests.Services
{
    public class FileServiceTests
    {
        private readonly FileService _fileService;
        private readonly Mock<IDirectoryProvider> _directoryProviderMock;

        public FileServiceTests()
        {
            _directoryProviderMock = new Mock<IDirectoryProvider>(MockBehavior.Strict);

            _fileService = new FileService(_directoryProviderMock.Object);
        }

        [Fact]
        public void RunFileCreation_WhenCall_ShouldCreateFile()
        {
            // Arrange
            const uint CHAPTER = 1;
            const string TEXT = "Fui criado com sucesso";
            const string FILE_NAME = "The Cursed Prince";
            const string LANGUAGE = "EN";
            const string PATH = "C:\\Users\\Jhonata\\Documents";
            const uint START_CHAPTER = 1;
            const uint END_CHAPTER = 10;

            FileConfiguration file = new(FILE_NAME, LANGUAGE, PATH, START_CHAPTER, END_CHAPTER);

            // Act
            _fileService.RunFileCreation(file, TEXT, CHAPTER);
        }
    }
}