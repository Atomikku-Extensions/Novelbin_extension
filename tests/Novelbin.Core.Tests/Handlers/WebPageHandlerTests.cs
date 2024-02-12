using FluentAssertions;
using HtmlAgilityPack;
using Novelbin.Core.Domain.Models;
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
            List<BookToSearch> result = await _webPageHandler.GetBooksAfterSearch(htmlNode);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(2);
            result[0].Tittle.Should().Be("The Cursed Prince");
            result[0].Url.Should().Contain("the-cursed-prince-nov1119906345");
            result[0].UrlImage.Should().Be("https://novelbin.net/media/novel_200_89/the-cursed-prince.jpg");
            result[1].Tittle.Should().Be("The Cursed Prince's Strange Bride");
            result[1].Url.Should().Contain("the-cursed-princes-strange-bride-nov-877285432");
            result[1].UrlImage.Should().Be("https://novelbin.net/media/novel_200_89/the-cursed-princes-strange-bride.jpg");
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