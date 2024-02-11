using FluentAssertions;
using HtmlAgilityPack;
using Novelbin.Core.Handlers;
using Novelbin.Core.Tests.Resources;

namespace Novelbin.Core.Tests.Handlers
{
    public class WebPageHandlerTests : BaseTests
    {
        private readonly WebPageHandler _webPageHandler;

        public WebPageHandlerTests()
        {
            _webPageHandler = new WebPageHandler();
        }

        [Fact]
        public async Task GetTitleOfPage_WhenCalled_ReturnsTitle()
        {
            // Arrange
            HtmlDocument doc = new();
            var html = HtmlFiles.SearchTheCursedPrinceHtml;

            doc.LoadHtml(html);
            var htmlNode = doc.DocumentNode;

            // Act
            var result = await _webPageHandler.GetBooksAfterSearch(htmlNode);
            var resultList = result.ToList();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(2);
            resultList[0].Key.Should().Be("The Cursed Prince");
            resultList[0].Value.Should().Be("https://novelbin.net/media/novel_200_89/the-cursed-prince.jpg");
            resultList[1].Key.Should().Be("The Cursed Prince's Strange Bride");
            resultList[1].Value.Should().Be("https://novelbin.net/media/novel_200_89/the-cursed-princes-strange-bride.jpg");
        }

        [Fact]
        public async Task GetChaptersOfPage_WhenCalled_ReturnsTitle()
        {
            // Arrange
            HtmlDocument doc = new();
            var html = HtmlFiles.TheCursedPrinceHtml;

            doc.LoadHtml(html);
            HtmlNode htmlNode = doc.DocumentNode;

            // Act
            var result = await _webPageHandler.GetChaptersOfPage(htmlNode);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(2);
        }
    }
}