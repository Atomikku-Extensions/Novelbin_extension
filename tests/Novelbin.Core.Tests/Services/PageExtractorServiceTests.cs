﻿using Moq;
using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Services;

namespace Novelbin.Core.Tests.Services
{
    public class PageExtractorServiceTests : BaseTests
    {
        public readonly PageExtractorService _pageExtractorService;

        private readonly Mock<IRequestService> _requestServiceMock;

        public PageExtractorServiceTests()
        {
            _requestServiceMock = new Mock<IRequestService>(MockBehavior.Strict);

            _pageExtractorService = new PageExtractorService(_requestServiceMock.Object);

            SetUp();
        }

        [Fact]
        public void StartExtractingPages_ShouldReturnTaskCompleted()
        {
            // Act
            var result = _pageExtractorService.StartExtractingPages(_data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Task.CompletedTask, result);
        }

        #region Private Methods

        private void SetUp()
        {
            _requestServiceMock.Setup(_ => _.GetPageStringWithXPath(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<List<string>>()))
                .Returns("Test");
        }

        #endregion Private Methods
    }
}