﻿using Moq;
using Moq.AutoMock;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Domain.Models;
using Novelbin.Core.Handlers;
using Novelbin.Core.Providers;
using Novelbin.Core.Services;

namespace Novelbin.Core.Tests.Providers
{
    public class MainProviderTests
    {
        private readonly MainProvider _mainProvider;

        private readonly Mock<ITranslatePageService> _translatePageServiceMock;
        private readonly Mock<IPageExtractorService> _pageExtractorServiceMock;
        private readonly Mock<IWebPageHandler> _webPageHandlerMock;
        private readonly Mock<IRequestService> _requestServiceMock;
        private readonly Mock<IFileService> _fileServiceMock;

        public MainProviderTests()
        {
            AutoMocker autoMocker = new();
            _translatePageServiceMock = new Mock<ITranslatePageService>(MockBehavior.Strict);
            _pageExtractorServiceMock = new Mock<IPageExtractorService>(MockBehavior.Strict);
            _requestServiceMock = new Mock<IRequestService>(MockBehavior.Strict);
            _webPageHandlerMock = new Mock<IWebPageHandler>(MockBehavior.Strict);
            _fileServiceMock = new Mock<IFileService>(MockBehavior.Strict);

            //_mainProvider = new MainProvider(
            //    //_translatePageServiceMock.Object,
            //    _pageExtractorServiceMock.Object,
            //    _requestServiceMock.Object,
            //    _webPageHandlerMock.Object,
            //    _fileServiceMock.Object);

            _mainProvider = new MainProvider(
                //_translatePageServiceMock.Object,
                autoMocker.CreateInstance<PageExtractorService>(),
                autoMocker.CreateInstance<RequestService>(),
                autoMocker.CreateInstance<WebPageHandler>(),
                autoMocker.CreateInstance<FileService>());

            SetUp();
        }

        [Fact]
        public async Task Execute_WhenCall_ShouldReturnsChapter()
        {
            // Arrange
            const string URL = "https://novelbin.net/n/the-cursed-prince/chapter-";
            const string XPATH = "//*[@id=\"chr-content\"]";
            const string XPATH_TITLE = "//*[@id=\"chapter\"]/div/div/h2/a";
            const string FILE_NAME = "The Cursed Prince";
            const string LANGUAGE = "EN";
            const string PATH = "C:\\Users\\Jhonata\\Documents";
            const uint START_CHAPTER = 1;
            const uint END_CHAPTER = 10;

            WebConfiguration web = new(URL, XPATH, XPATH_TITLE);
            FileConfiguration file = new(FILE_NAME, LANGUAGE, PATH, START_CHAPTER, END_CHAPTER);

            // Act
            await _mainProvider.Execute(new Data(web, file));

            // Assert
        }

        #region Private Methods

        private void SetUp()
        {
            _translatePageServiceMock.Setup(_ => _.Translate(It.IsAny<string>())).ReturnsAsync("");
            _pageExtractorServiceMock.Setup(_ => _.StartExtractingPages(It.IsAny<Data>())).Returns(Task.CompletedTask);
            _fileServiceMock.Setup(_ => _.CheckFolders(It.IsAny<Data>())).Returns(Task.CompletedTask);
            _fileServiceMock.Setup(_ => _.StartCreatingFiles(It.IsAny<Data>())).Returns(Task.CompletedTask);
        }

        #endregion Private Methods
    }
}